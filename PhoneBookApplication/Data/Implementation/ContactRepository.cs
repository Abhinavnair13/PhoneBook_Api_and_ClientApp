using PhoneBookApplication.Data.Contract;
using PhoneBookApplication.Models;

namespace PhoneBookApplication.Data.Implementation
{
    public class ContactRepository: IContactRepository
    {
        private readonly AppDbContext _appDbContext;
        public ContactRepository(AppDbContext dbContext)
        {
            _appDbContext = dbContext;

            
        }


        public bool Create(PhoneBook contact)
        {
            var result = false;
            if (contact != null)
            {
                _appDbContext.PhoneBooks.Add(contact);
                _appDbContext.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool Delete(int id)
        {
            var result = false;
            var contact = _appDbContext.PhoneBooks.Find(id);
            if (contact != null)
            {
                _appDbContext.PhoneBooks.Remove(contact);
                _appDbContext.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool Edit(PhoneBook contact)
        {
            var result = false;
            if (contact != null)
            {
                _appDbContext.PhoneBooks.Update(contact);
                _appDbContext.SaveChanges();
                result = true;
            }
            return result;
        }

        public IEnumerable<PhoneBook> GetAll()
        {
            List<PhoneBook> contact = _appDbContext.PhoneBooks.ToList();
            return contact;
        }

        public PhoneBook? GetContact(int id)
        {
            var contact = _appDbContext.PhoneBooks.FirstOrDefault(c=>c.PhoneId==id);
            return contact;
        }

        public int TotalContacts()
        {
            return _appDbContext.PhoneBooks.Count();
        }
        public bool ContactExists(int phoneId, string contactNumber)
        {
            var contact = _appDbContext.PhoneBooks.FirstOrDefault(c => c.PhoneId == phoneId &&
           c.ContactNumber == contactNumber);
            if (contact != null)
            {
                return true;
            }
            return false;
        }

        public bool ContactExists(string contactNumber)
        {
            var contact = _appDbContext.PhoneBooks.FirstOrDefault(c => c.ContactNumber == contactNumber);
            if (contact != null)
            {
                return true;
            }
            return false;
        }
        public IEnumerable<PhoneBook> GetPaginatedPhoneBooks(int page, int pageSize)
        {
            int skip = (page - 1) * pageSize;
            return _appDbContext.PhoneBooks
                .OrderBy(c => c.FirstName)
                .Skip(skip)
                .Take(pageSize)
                .ToList();
        }

        public IEnumerable<PhoneBook> GetPaginatedContactBookWithCharacter(char? character, int page, int pageSize)
        {
            int skip = (page - 1) * pageSize;
            return _appDbContext.PhoneBooks
                .Where(c => c.FirstName.StartsWith(character.ToString().ToLower()))
                .OrderBy(c => c.FirstName)
                .Skip(skip)
                .Take(pageSize)
                .ToList();
        }
    }
}
