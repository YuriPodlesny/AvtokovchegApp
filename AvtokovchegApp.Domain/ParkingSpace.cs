using AvtokovchegApp.Domain.Core;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace AvtokovchegApp.Domain
{
    public class ParkingSpace
    {
        [Key]
        public int Namber { get; set; }
        public bool IsFree { get; set; } = true;
        public int Floor { get; set; }

        public List<Renter> Renters { get; set; } = new();
        public List<Agreement> Agreements { get; set; } = new();
    }
}