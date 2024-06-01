using PhoneBookAppApi.Data.Contract;
using PhoneBookAppApi.Dtos;
using PhoneBookAppApi.Models;
using PhoneBookAppApi.Service.Contract;

namespace PhoneBookAppApi.Service.Implementation
{
    public class ContactService: IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public int TotalContacts()
        {
            return _contactRepository.TotalContacts();
        }

     
        public ServiceResponse<IEnumerable<ContactDto>> GetAllContact()
        {
            var response = new ServiceResponse<IEnumerable<ContactDto>>();
            var contacts = _contactRepository.GetAll();

            if (contacts == null)
            {
                response.Success = false;
                response.Data = new List<ContactDto>();
                response.Message = "No record found.";
                return response;
            }

            List<ContactDto> contactDtos = new List<ContactDto>();
            foreach (var contact in contacts)
            {
                contactDtos.Add(new ContactDto()
                {
                    contactId = contact.PhoneId,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Email = contact.Email,
                    Company = contact.CompanyName,
                    ContactNumber = contact.ContactNumber,
                    FileName = contact.FileName,


                });
            }

            response.Data = contactDtos;
            return response;
        }

        public ServiceResponse<ContactDto> GetContactById(int id)
        {
            var response = new ServiceResponse<ContactDto>();

            var contact = _contactRepository.GetContact(id);

            var contactDto = new ContactDto()
            {
                contactId = contact.PhoneId,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                Company = contact.CompanyName,
                ContactNumber = contact.ContactNumber,
                FileName = contact.FileName,
            };

            response.Data = contactDto;
            return response;
        }


        public ServiceResponse<string> AddContact(Contact contact, IFormFile file)
        {

            var response = new ServiceResponse<string>();

            if (contact == null)
            {
                response.Success = false;
                response.Message = "Something went wrong. Please try after sometime.";
                return response;
            }

            if (_contactRepository.ContactExists(contact.PhoneId, contact.ContactNumber))
            {
                response.Success = false;
                response.Message = "Contact already exists.";
                return response;
            }

            var fileName = string.Empty;
            if (file != null && file.Length > 0)
            {
                // Process the uploaded file(eq. save it to disk)
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", file.FileName);

                // Save the file to storage and set path
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    fileName = file.FileName;
                }
                contact.FileName = fileName;
            }

            var result = _contactRepository.InsertContact(contact);
            response.Success = result;
            response.Message = result ? "Contact saved successfully." : "Something went wrong. Please try after sometime.";

            return response;

        }

        public ServiceResponse<string> ModifyContact(UpdateContactDto contact)
        {
            var response = new ServiceResponse<string>();

            if (contact == null)
            {
                response.Success = false;
                response.Message = "Something went wrong. Please try after sometime.";
                return response;
            }

            if (_contactRepository.ContactExists(contact.contactId, contact.ContactNumber))
            {
                response.Success = false;
                response.Message = "Contact already exists.";
                return response;
            }

            var modifyContact = _contactRepository.GetContact(contact.contactId);
            if (modifyContact != null)
            {
                modifyContact.FirstName = contact.FirstName;
                modifyContact.LastName = contact.LastName;
                modifyContact.Email = contact.Email;
                modifyContact.CompanyName = contact.Company;
                modifyContact.ContactNumber = contact.ContactNumber;

                var result = _contactRepository.UpdateContact(modifyContact);

                response.Success = result;
                response.Message = result ? "Contact updated successfully." : "Something went wrong. Please try after sometime.";
            }
            else
            {
                response.Success = false;
                response.Message = "Something went wrong. Please try after sometime.";
                return response;
            }


           
            return response;
        }

        public ServiceResponse<string> RemoveContact(int id)
        {
            var response = new ServiceResponse<string>();

            if (id < 0)
            {
                response.Success = false;
                response.Message = "No record to delete.";

            }

            var result = _contactRepository.DeleteContact(id);
            response.Success = result;
            response.Message = result ? "Contact deleted successfully." : "Something went wrong, please try after sometime.";
            return response;
        }
    }
}
