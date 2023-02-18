using AvtokovchegApp.Domain;
using AvtokovchegApp.Domain.Core;

namespace AvtokovchegApp.Models
{
    public class RequestViewModel
    {
        public Renter Renter { get; set; }
        public HolderCar Holder { get; set; }
        public Car Car { get; set; }
        public int ParkingSpaceId { get; set; }
    }
}
