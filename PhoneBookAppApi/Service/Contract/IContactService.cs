using PhoneBookAppApi.Dtos;
using PhoneBookAppApi.Models;

namespace PhoneBookAppApi.Service.Contract
{
    public interface IContactService
    {
        int TotalContacts();

        ServiceResponse<IEnumerable<ContactDto>> GetAllContact();

        ServiceResponse<ContactDto> GetContactById(int id);

        ServiceResponse<string> AddContact(Contact contact, IFormFile file);

        ServiceResponse<string> ModifyContact(UpdateContactDto contact);

        ServiceResponse<string> RemoveContact(int id);
    }
}
