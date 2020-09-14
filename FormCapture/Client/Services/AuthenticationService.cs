using FormCapture.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;

namespace FormCapture.Client.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;

        private readonly ILocalStorageService _localStorageService;

        private readonly AuthenticationStateProvider _authenticationStateProvider;

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
                await _localStorageService.SetItemAsync("userEmail", loginModel.Email);
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
