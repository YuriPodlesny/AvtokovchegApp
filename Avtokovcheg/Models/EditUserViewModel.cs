using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AvtokovchegApp.Models
{
    public class EditUserViewModel
    {
        public string UserName { get; set; }

        [Required(ErrorMessage = "Укажите имя")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите фамилию")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Укажите отчество")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [Required(ErrorMessage = "Не указан номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }
        
    }
}
