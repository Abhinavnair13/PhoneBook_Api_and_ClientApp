using PhoneBookApplication.ViewModel;

namespace PhoneBookApplication.Service.Contract
{
    public interface IAuthService
    {
        string LoginUserService(LoginViewModel login);
        string RegisterUserService(RegisterViewModel register);
    }
}
