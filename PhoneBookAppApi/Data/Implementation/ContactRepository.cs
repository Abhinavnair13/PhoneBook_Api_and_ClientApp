using PhoneBookAppApi.Data.Contract;
using PhoneBookAppApi.Models;

namespace PhoneBookAppApi.Data.Implementation
{
    public class ContactRepository: IContactRepository
    {
        private AppDbContext _appDbContext;

        public ContactRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Contact> GetAll()
        {
            List<Contact> contact = _appDbContext.Contacts.ToList();
            return contact;
        }

        public int TotalContacts()
        {
            return _appDbContext.Contacts.Count();
        }

        public IEnumerable<Contact> GetPaginatedContacts(int page, int pageSize)
        {
            int skip = (page - 1) * pageSize;
            return _appDbContext.Contacts
                .OrderBy(c => c.PhoneId)
                .Skip(skip)
                .Take(pageSize)
                .ToList();
        }

        public Contact? GetContact(int id)
        {
            var contact = _appDbContext.Contacts.FirstOrDefault(c => c.PhoneId == id);
            return contact;
        }

        public bool InsertContact(Contact contact)
        {
            var result = false;
            if (contact != null)
            {
                _appDbContext.Contacts.Add(contact);
                _appDbContext.SaveChanges();
                result = true;
            }

            return result;
        }

        public bool UpdateContact(Contact contacts)
        {
            var result = false;
            if (contacts != null)
            {
                _appDbContext.Contacts.Update(contacts);
            
                _appDbContext.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool DeleteContact(int id)
        {
            var result = false;
            var c = _appDbContext.Contacts.Find(id);
            if (c != null)
            {
                _appDbContext.Contacts.Remove(c);
                _appDbContext.SaveChanges();
                result = true;
            }

            return result;
        }


        public bool ContactExists(string number)
        {
            var c = _appDbContext.Contacts.FirstOrDefault(c => c.ContactNumber == number);
            if (c != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ContactExists(int contactId, string num)
        {
            var c = _appDbContext.Contacts.FirstOrDefault(c => c.PhoneId != contactId && c.ContactNumber == num);
            if (c != null)
            {
                return true;
            }

            else
            {
                return false;
            }

        }
    }
}
