using PhoneBookApplication.Models;

namespace PhoneBookApplication.Service.Contract
{
    public interface IContactService
    {
        IEnumerable<PhoneBook> GetAll();
        string AddContact(PhoneBook contact,IFormFile file);
        string EditContact(PhoneBook contact);
        string RemoveContact(int id);
        PhoneBook? GetContact(int id);
        int TotalCount();
        public IEnumerable<PhoneBook> GetPaginatedPhoneBooks(int page, int pageSize);
        public IEnumerable<PhoneBook> GetPaginatedPhoneBooksWithCharacter(char? character, int page, int pageSize);



    }
}
