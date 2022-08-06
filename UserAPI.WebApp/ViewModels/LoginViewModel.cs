using System.ComponentModel.DataAnnotations;

namespace UserAPI.WebApp.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "Password min 4 must be character")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = string.Empty;
    }
}
