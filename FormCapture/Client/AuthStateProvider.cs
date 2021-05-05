using Blazored.LocalStorage;
using FormCapture.Client.Helpers;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace FormCapture.Client
{
    /// <summary>
    /// Authentication state provider class.
    ///
    /// Sources:
    /// SAINTY, Chris, 2019. Authentication with client-side Blazor using WebAPI and ASP.NET Core Identity. Chris Sainty [online]. [vid. 2021-04-29]. Dostupné z: https://chrissainty.com/securing-your-blazor-apps-authentication-with-clientside-blazor-using-webapi-aspnet-core-identity/
    /// </summary>
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;

        public AuthStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = await _localStorage.GetItemAsync<string>("token");
            if (string.IsNullOrEmpty(token))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt")));
        }

        public void SetUserAsAuthenticated(string token)
        {
            ClaimsPrincipal user = new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt"));
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public void SetUserAsLogedOut()
        {
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()))));
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2:
                    base64 += "==";
                    break;

                case 3:
                    base64 += "=";
                    break;
            }
            return Convert.FromBase64String(base64);
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            List<Claim> claims = new List<Claim>();
            string payload = jwt.Split('.')[1];
            byte[] jsonBytes = ParseBase64WithoutPadding(payload);
            Dictionary<string, object> keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);
            claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));
            ClaimsHelper.Instance().SetClaims(claims);
            ClaimsHelper.Instance().SetToken(jwt);
            return claims;
        }
    }
}