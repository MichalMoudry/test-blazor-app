using System.ComponentModel.DataAnnotations;

namespace FormCapture.Shared
{
    /// <summary>
    /// Registration model class.
    /// 
    /// Source:
    /// SAINTY, Chris, 2019. Authentication with client-side Blazor using WebAPI and ASP.NET Core Identity. Chris Sainty [online]. [vid. 2021-04-29]. Dostupné z: https://chrissainty.com/securing-your-blazor-apps-authentication-with-clientside-blazor-using-webapi-aspnet-core-identity/
    /// </summary>
    public class RegistrationModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmationPassword { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(1000, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"(^Admin$|^Workflow admin$|^User$)")]
        public string Role { get; set; }
    }
}