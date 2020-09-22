using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FormCapture.Client.Helpers
{
    public class ClaimsHelper
    {
        private static ClaimsHelper instance;

        private List<Claim> claims;

        private string token;

        public static ClaimsHelper Instance()
        {
            if (instance == null)
            {
                instance = new ClaimsHelper();
            }
            return instance;
        }

        protected ClaimsHelper()
        {

        }

        public void SetClaims(List<Claim> claims)
        {
            this.claims = claims;
        }

        public void SetToken(string jwt)
        {
            token = jwt;
        }

        public List<Claim> GetClaims()
        {
            return claims;
        }

        public string GetToken()
        {
            return token;
        }

        public Claim GetRoleClaim()
        {
            try
            {
                return claims.Where(i => i.Type.Equals(ClaimTypes.Role)).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Claim GetEmailClaim()
        {
            try
            {
                return claims.Where(i => i.Type.Equals(ClaimTypes.Email)).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Claim GetExpirationClaim()
        {
            try
            {
                return claims.Where(i => i.Type.Equals("exp")).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}