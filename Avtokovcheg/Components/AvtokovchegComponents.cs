using Avtokovcheg.Domain.Interfaces;
using AvtokovchegApp.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AvtokovchegApp.Components
{
    public class ParkingSpaceViewComponent : ViewComponent
    {
        IParkingSpaceRepository _parkingSpace;

        public ParkingSpaceViewComponent(IParkingSpaceRepository parkingSpace)
        {
            _parkingSpace = parkingSpace;
        }

        public IViewComponentResult Invoke(int floor)
        {
            var parkingSpace = _parkingSpace.GetParkingSpaceFloor(floor);
            return View(parkingSpace);
        }
    }
}
