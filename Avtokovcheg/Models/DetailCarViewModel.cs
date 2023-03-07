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

        [Display(Name = "Имя владельца")]
        public string HolderName { get; set; }

        [Display(Name = "Отчество владельца")]
        public string HolderPatronymic { get; set; }

        [Display(Name = "Фамилия владельца")]
        public string HolderSurname { get; set; }
    }
}
