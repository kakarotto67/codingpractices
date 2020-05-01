using System.ComponentModel.DataAnnotations;

namespace GCBL.CoreSite.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Login name")]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}