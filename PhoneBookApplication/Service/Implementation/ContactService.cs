using PhoneBookApplication.Data;
using PhoneBookApplication.Data.Contract;
using PhoneBookApplication.Models;
using PhoneBookApplication.Service.Contract;

namespace PhoneBookApplication.Service.Implementation
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private const string alreadyExists = "Contact already exists.";
        private const string wentWrong = "Something went wrong, try again later";
        private const string savedSuccess = "Contact saved successfully.";
        private const string deleteSuccess = "Contact deleted successfully.";
        private const string updateSuccess = "Contact updated successfully.";
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
            
        }
        public string AddContact(PhoneBook contact,IFormFile file)
        {
            if (_contactRepository.ContactExists(contact.ContactNumber))
            {
                return alreadyExists;
            }
            var fileName = string.Empty;
            if (file != null && file.Length > 0)
            {
                //Process the uploaded file(save to disk)/
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", file.FileName);
                //Save the file to storage and set path
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    fileName = file.FileName;
                }
                contact.FileName = fileName;

            }
            var result = _contactRepository.Create(contact);
            return result ? savedSuccess : wentWrong;
        }

        public string RemoveContact(int id)
        {
            var result = _contactRepository.Delete(id);
            if (result)
            {
                return deleteSuccess;

            }
            else
            {
                return wentWrong;
            }
        }

        public string EditContact(PhoneBook contact)
        {
            var message = string.Empty;
            if (_contactRepository.ContactExists(contact.PhoneId, contact.ContactNumber))
            {
                message = alreadyExists;
                return message;



            }
            var existingContact = _contactRepository.GetContact(contact.PhoneId);
            var result = false;
            if (existingContact != null)
            {
                existingContact.ContactNumber = contact.ContactNumber;
                existingContact.FirstName = contact.FirstName;
                existingContact.LastName = contact.LastName;
                existingContact.CompanyName = contact.CompanyName;
                existingContact.Email = contact.Email;
                result = _contactRepository.Edit(existingContact);
            }
            return result ? updateSuccess : wentWrong;
        }

        public IEnumerable<PhoneBook> GetAll()
        {
            var contacts = _contactRepository.GetAll();
            if (contacts != null && contacts.Any())
            {
                foreach(var contact in contacts.Where(c=>c.FileName==string.Empty))
                {
                    contact.FileName = "DefaultContact.png";
                }
                return contacts;

            }
            return new List<PhoneBook>();
        }

        public PhoneBook? GetContact(int id)
        {
            var contact = _contactRepository.GetContact(id);

            return contact;
        }

        public int TotalCount()
        {
            return _contactRepository.TotalContacts();

        }
        public IEnumerable<PhoneBook> GetPaginatedPhoneBooks(int page, int pageSize)
        {


            return _contactRepository.GetPaginatedPhoneBooks(page, pageSize);
        }
        public IEnumerable<PhoneBook> GetPaginatedPhoneBooksWithCharacter(char? character,int page, int pageSize)
        {
            return _contactRepository.GetPaginatedContactBookWithCharacter(character,page, pageSize);
        }
    }
}
