using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AvtokovchegApp.Models
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Не указан номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Номер телефона")]
        public string PhoneNamber { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Длина пароля должна быть больше 6 символов")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string NewPassword { get; set; }
    }
}
