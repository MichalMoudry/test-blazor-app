using System.Threading.Tasks;
using FormCapture.Shared;

namespace FormCapture.Client.Services
{
    /// <summary>
    /// Interface for implementation of authentication service.
    /// 
    /// Source:
    /// SAINTY, Chris, 2019. Authentication with client-side Blazor using WebAPI and ASP.NET Core Identity. Chris Sainty [online]. [vid. 2021-04-29]. Dostupné z: https://chrissainty.com/securing-your-blazor-apps-authentication-with-clientside-blazor-using-webapi-aspnet-core-identity/
    /// </summary>
    public interface IAuthenticationService
    {
        public Task<bool> RegisterUser(RegistrationModel registrationModel);

        public Task<bool> LoginUser(LoginModel loginModel);

        public Task<bool> LogoutUser();
    }
}