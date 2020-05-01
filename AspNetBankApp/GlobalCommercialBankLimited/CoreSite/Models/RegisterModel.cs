using System.ComponentModel.DataAnnotations;

namespace GCBL.CoreSite.Models
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "Login name")]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(12, MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}