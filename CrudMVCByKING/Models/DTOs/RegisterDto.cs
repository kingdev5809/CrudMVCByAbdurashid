using System.ComponentModel.DataAnnotations;

namespace CrudMVCByKING.Models.DTOs
{
    public class RegisterDto
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }

        [Display(Name = "Name address")]
        [Required(ErrorMessage = "Name address is required")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
