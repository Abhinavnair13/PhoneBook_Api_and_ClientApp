using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBookAppApi.Dtos;
using PhoneBookAppApi.Models;
using PhoneBookAppApi.Service.Contract;

namespace PhoneBookAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }


        [HttpGet("GetAllContact")]
        public IActionResult GetAllContacts()
        {
            var response = _contactService.GetAllContact();
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("GetContactById/{id}")]
        public IActionResult GetContactById(int id)
        {
            var response = _contactService.GetContactById(id);

            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }


        [HttpPost("Create")]
        public IActionResult AddContact(AddContactDto addContactDto)
        {
            var contact = new Contact()
            {
                FirstName = addContactDto.FirstName,
                LastName = addContactDto.LastName,
                Email = addContactDto.Email,
                CompanyName = addContactDto.Company,
                ContactNumber = addContactDto.ContactNumber,
                FileName = addContactDto.FileName,

            };

            var result = _contactService.AddContact(contact, addContactDto.File);

            return !result.Success ? BadRequest(result) : Ok(result);
        }

        [HttpPut("ModifyContact")]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            var contact = new Contact()
            {
                PhoneId = updateContactDto.contactId,
                FirstName = updateContactDto.FirstName,
                LastName = updateContactDto.LastName,
                Email = updateContactDto.Email,
                CompanyName = updateContactDto.Company,
                ContactNumber = updateContactDto.ContactNumber,

            };

            var result = _contactService.ModifyContact(updateContactDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpDelete("Remove/{id}")]
        public IActionResult RemoveContact(int id)
        {
            if (id > 0)
            {
                var response = _contactService.RemoveContact(id);
                if (!response.Success)
                {
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            else
            {
                return BadRequest("Please enter proper data.");
            }

        }

    }
}
