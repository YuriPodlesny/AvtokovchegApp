using System.ComponentModel.DataAnnotations;

namespace AvtokovchegApp.Models
{
    public class ChangeStatusParkingSpaceViewModel
    {
        [Required]
        public int Namber { get; set; }

        [Required(ErrorMessage = "Укажите свободно ли место")]
        [Display(Name = "Статус места")]
        public bool IsFree { get; set; }
    }
}
