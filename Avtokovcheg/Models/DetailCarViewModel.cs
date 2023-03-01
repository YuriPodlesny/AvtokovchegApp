using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AvtokovchegApp.Models
{
    public class DetailCarViewModel
    {
        [Display(Name = "Марка автомобиля")]
        public string CarBrand { get; set; }

        [Display(Name = "Модель автомобиля")]
        public string CarModel { get; set; }

        [Display(Name = "Номер автомобиля")]
        public string Namber { get; set; }

        [Display(Name = "Имя арендатора")]
        public string UserName { get; set; }

        [Display(Name = "Отчество арендатора")]
        public string UserPatronymic { get; set; }

        [Display(Name = "Фамилия арендатора")]
        public string UserSurname { get; set; }

        [Display(Name = "Номер телефона арендатора")]
        public string UserPhoneNamber { get; set; }


        [Display(Name = "Имя владельца")]
        public string HolderName { get; set; }

        [Display(Name = "Отчество владельца")]
        public string HolderPatronymic { get; set; }

        [Display(Name = "Фамилия владельца")]
        public string HolderSurname { get; set; }


    }
}
