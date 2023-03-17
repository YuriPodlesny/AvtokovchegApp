using AvtokovchegApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AvtokovchegApp.Components
{
    public class ParkingSpaceViewComponent : ViewComponent
    {
        private readonly IParkingSpaceRepository _parkingSpace;

        public ParkingSpaceViewComponent(IParkingSpaceRepository parkingSpace)
        {
            _parkingSpace = parkingSpace;
        }

        public IViewComponentResult Invoke(int floor)
        {
            var parkingSpace = _parkingSpace.GetParkingSpaceByFloor(floor);
            return View(parkingSpace);
        }
    }
}
