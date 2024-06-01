using PhoneBookApplication.Models;

namespace PhoneBookApplication.Data.Contract
{
    public interface IContactRepository
    {
        IEnumerable<PhoneBook> GetAll();
        bool Create(PhoneBook contact);
        bool Edit(PhoneBook contact);
        bool Delete(int id);
        PhoneBook? GetContact(int id);
        public int TotalContacts();
        bool ContactExists(int phoneId, string contactNumber);
        bool ContactExists(string contactNumber);
        public IEnumerable<PhoneBook> GetPaginatedPhoneBooks(int page, int pageSize);

        public IEnumerable<PhoneBook> GetPaginatedContactBookWithCharacter(char? character, int page, int pageSize);
    }
}
