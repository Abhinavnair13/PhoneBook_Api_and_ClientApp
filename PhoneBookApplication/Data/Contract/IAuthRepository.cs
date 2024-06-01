using PhoneBookApplication.Models;

namespace PhoneBookApplication.Data.Contract
{
    public interface IAuthRepository
    {
        bool RegisterUser(User user);

        User? ValidateUser(string username);

        bool UserExists(string loginId, string email);
    }
}
