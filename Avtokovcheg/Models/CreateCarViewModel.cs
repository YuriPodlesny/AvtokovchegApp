using System.ComponentModel.DataAnnotations;

namespace AvtokovchegApp.Models
{
    public class CreateCarViewModel
    {
        [Required(ErrorMessage = "Укажите марку автомобиля")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Марка автомобиля")]
        public string CarBrand { get; set; }

        [Required(ErrorMessage = "Укажите модель автомобиля")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Модель автомобиля")]
        public string CarModel { get; set; }

        [Required(ErrorMessage = "Укажите номер автомобиля(или WIN)")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Номер автомобиля")]
        public string Namber { get; set; }

        [Required(ErrorMessage = "Укажите имя владельца")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Имя владельца")]
        public string HolderName { get; set; }

        [Required(ErrorMessage = "Укажите отчество владельца")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Отчество владельца")]
        public string HolderPatronymic { get; set; }

        [Required(ErrorMessage = "Укажите фамилию владельца")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Фамилия владельца")]
        public string HolderSurname { get; set; }

        [Required]
        public int СontractSpaceId { get; set; }

    }
}
