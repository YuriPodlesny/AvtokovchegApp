using AvtokovchegApp.Domain.Core;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Xml.Linq;

namespace AvtokovchegApp.Models
{
    public class CreateContractViewModel
    {
        [Required(ErrorMessage = "Укажите дату договора")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата договора")]
        public DateTime DateStart { get; set; }

        [Display(Name = "Срок договора")]
        public int DateEnd { get; set; }

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
        public int NamberSpace { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
