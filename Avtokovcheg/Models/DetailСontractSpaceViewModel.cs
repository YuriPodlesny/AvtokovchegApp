using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AvtokovchegApp.Models
{
    public class DetailСontractSpaceViewModel
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата договора")]
        public DateTime DateStart { get; set; }

        [Display(Name = "Срок договора")]
        public int DateEnd { get; set; }

        [Display(Name = "Период оплаты договора")]
        public int Time { get; set; }

        [Display(Name = "Номер договора")]
        public string NamberContract { get; set; }

        [Display(Name = "Номер парковочного места")]
        public int NamberSpace { get; set; }

        [Display(Name = "Имя арендатора")]
        public string UserName { get; set; }

        [Display(Name = "Отчество арендатора")]
        public string UserPatronymic { get; set; }

        [Display(Name = "Фамилия арендатора")]
        public string UserSurname { get; set; }

        [Display(Name = "Номер телефона арендатора")]
        public string UserPhoneNamber { get; set; }
    }
}
