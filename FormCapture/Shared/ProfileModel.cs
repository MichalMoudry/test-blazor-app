using System.ComponentModel.DataAnnotations;

namespace FormCapture.Shared
{
    public class ProfileModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(1000, MinimumLength = 6)]
        public string NewPassword { get; set; }
    }
}