using System.ComponentModel.DataAnnotations;

namespace AvtokovchegApp.Domain
{
    public class ParkingSpace
    {
        [Key]
        public int Namber { get; set; }
        public bool IsFree { get; set; } = true;
        public int Floor { get; set; }
    }
}