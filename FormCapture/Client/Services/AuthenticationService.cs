using Blazored.LocalStorage;
using FormCapture.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FormCapture.Client.Services
{
    /// <summary>
    /// Authentication service class.
    /// 
    /// Sources:
    /// SAINTY, Chris, 2019. Authentication with client-side Blazor using WebAPI and ASP.NET Core Identity. Chris Sainty [online]. [vid. 2021-04-29]. Dostupné z: https://chrissainty.com/securing-your-blazor-apps-authentication-with-clientside-blazor-using-webapi-aspnet-core-identity/
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly HttpClient _httpClient;

        private readonly ILocalStorageService _localStorageService;

        public AuthenticationService(HttpClient httpClient, ILocalStorageService localStorage, AuthenticationStateProvider provider)
        {
            _httpClient = httpClient;
            _localStorageService = localStorage;
            _authenticationStateProvider = provider;
        }

        public async Task<bool> LoginUser(LoginModel loginModel)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("api/users/login", loginModel);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string token = await httpResponseMessage.Content.ReadAsStringAsync();
                await _localStorageService.SetItemAsync("token", token);
                ((AuthStateProvider)_authenticationStateProvider).SetUserAsAuthenticated(token);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> LogoutUser()
        {
            try
            {
                await _localStorageService.RemoveItemAsync("token");
                ((AuthStateProvider)_authenticationStateProvider).SetUserAsLogedOut();
                _httpClient.DefaultRequestHeaders.Authorization = null;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> RegisterUser(RegistrationModel registrationModel)
        {
            HttpResponseMessage res = await _httpClient.PostAsJsonAsync("api/users/register", registrationModel);
            if (res.IsSuccessStatusCode)
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