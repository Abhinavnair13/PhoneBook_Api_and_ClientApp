using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneBookApplication.Data;
using PhoneBookApplication.Models;
using PhoneBookApplication.Service.Contract;
using PhoneBookApplication.ViewModel;

namespace PhoneBookApplication.Controllers
{
    public class PhoneBookController : Controller
    {
        
        private IContactService _contactService;
        private const string alreadyExists = "Contact already exists.";
        private const string wentWrong = "Something went wrong, try again later";
        private const string savedSuccess = "Contact saved successfully.";
        private const string deleteSuccess = "Contact deleted successfully.";
        private const string updateSuccess = "Contact updated successfully.";
        public PhoneBookController(IContactService contactService)
        {
            _contactService = contactService;
          
         
            
        }

        public IActionResult Index(char? character,int page = 1,int pageSize = 2 )
        {


         
           
           
            // Get total count of categories
            var totalCount = _contactService.GetAll().Count();

            // Calculate total number of pages
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var contacts = character == null ? _contactService.GetPaginatedPhoneBooks(page, pageSize) : _contactService.GetPaginatedPhoneBooksWithCharacter(character, page, pageSize);
          
            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = page; // Pass the current page number to the ViewBag
            ViewBag.PageSize = pageSize;
            ViewBag.Character = character;
            return View(contacts);
        }
        public IActionResult Details(int id)
        {
            var contact = _contactService.GetContact(id);
            if (contact == null)
            {
                return NotFound();
            }
            return  View(contact);
        }
        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(PhoneBookViewModel contactViewModel)

        {
            if (ModelState.IsValid)
            {
                var contact = new PhoneBook()
                {
                    FirstName = contactViewModel.FirstName,
                    LastName = contactViewModel.LastName,
                    CompanyName = contactViewModel.CompanyName,
                    Email = contactViewModel.Email,
                    ContactNumber = contactViewModel.ContactNumber,
                   
                };
                var result = _contactService.AddContact(contact,contactViewModel.File);
                if(result== alreadyExists ||  result== wentWrong)
                {
                    TempData["ErrorMessage"] = result;
                }
                else if(result== savedSuccess)
                {
                    TempData["SuccessMessage"] = result;
                    return RedirectToAction("Index");
                }
            }
            return View(contactViewModel);

        }
        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {
            var contact = _contactService.GetContact(id);
            if (contact == null)
            {
                return NotFound();

            }
            return View(contact);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Edit(PhoneBook contact)
        {
            if (ModelState.IsValid)
            {
                var result = _contactService.EditContact(contact);
                if(result==wentWrong || result == alreadyExists)
                {
                    TempData["ErrorMessage"] = result;
                }
                else
                {
                    TempData["SuccessMessage"] = result;
                    return RedirectToAction("Index");
                }
            }
            return View(contact);
        }
        [Authorize]
        public IActionResult Delete(int id)
        {
            var contact = _contactService.GetContact(id);
            if (contact == null)
            {
                return NotFound();

            }
            else
            {

                return View(contact);

            }
        }
        [Authorize]
        [HttpPost]
        public IActionResult DeleteConfirm(int PhoneId)
        {
            var result = _contactService.RemoveContact(PhoneId);
            if (result == deleteSuccess)
            {
                TempData["SuccessMessage"] = result;
            }
            else
            {
                TempData["ErrorMessage"] = result;  
            }
            return RedirectToAction("Index");



        }
      
    }
}
