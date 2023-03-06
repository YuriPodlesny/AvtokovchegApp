using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AvtokovchegApp.Models
{
    public class EditСontractSpaceViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите дату договора")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата договора")]
        public DateTime DateStart { get; set; }

        [Display(Name = "Срок договора")]
        public int? DateEnd { get; set; }

        [Required(ErrorMessage = "Укажите период оплаты договора")]
        [Display(Name = "Период оплаты договора")]
        public int Time { get; set; }

        [Required(ErrorMessage = "Укажите номер договора")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Номер договора")]
        public string NamberContract { get; set; }

        [Required(ErrorMessage = "Укажите номер парковочного места")]
        [Display(Name = "Номер парковочного места")]
        [Range(1, 567, ErrorMessage = "Номер парковочного места должен быть от 1 до 567")]
        public int NamberSpace { get; set; }

        [Required(ErrorMessage = "Укажите стоимость периода оплаты")]
        [Display(Name = "Стоимость периода оплаты по догвору")]
        public double Cost { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
