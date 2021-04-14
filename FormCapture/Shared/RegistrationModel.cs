using System.ComponentModel.DataAnnotations;

namespace FormCapture.Shared
{
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