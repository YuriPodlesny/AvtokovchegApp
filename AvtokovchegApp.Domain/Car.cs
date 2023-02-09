using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtokovchegApp.Domain.Core
{
    public class Car
    {
        public int Id { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public string? Namber { get; set; }
        public string? VIN { get; set; }

        public int RenterId { get; set;}
        public Renter? Renter { get; set; }

        public int HolderCarId { get; set; }
        public HolderCar? HolderCar { get; set; }
    }
}
