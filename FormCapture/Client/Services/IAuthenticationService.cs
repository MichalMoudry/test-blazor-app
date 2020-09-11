using System.Threading.Tasks;
using FormCapture.Shared;

namespace FormCapture.Client.Services
{
    public interface IAuthenticationService
    {
        public Task<bool> RegisterUser(RegistrationModel registrationModel);

        public Task<bool> LoginUser(LoginModel loginModel);

        public Task<bool> LogoutUser();
    }
}