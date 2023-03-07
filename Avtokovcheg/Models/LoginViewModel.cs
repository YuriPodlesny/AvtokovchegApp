using System.ComponentModel.DataAnnotations;

namespace AvtokovchegApp.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Логин(номер телефона)")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set;}

        public string? ReturnUrl { get; set; }
    }
}
