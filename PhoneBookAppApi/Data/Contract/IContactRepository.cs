using PhoneBookAppApi.Models;

namespace PhoneBookAppApi.Data.Contract
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetAll();

        Contact? GetContact(int id);

        bool ContactExists(string num);

        bool ContactExists(int contactId, string num);

        bool InsertContact(Contact c);

        bool UpdateContact(Contact contacts);

        bool DeleteContact(int contactId);

        IEnumerable<Contact> GetPaginatedContacts(int page, int pageSize);

        int TotalContacts();
    }
}
