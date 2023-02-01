using Avtokovcheg.Domain.Interfaces;
using AvtokovchegApp.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AvtokovchegApp.Components
{
    public class ParkingSpaceViewComponent : ViewComponent
    {
        IParkingSpaceRepository _parkingSpace;

        public ParkingSpaceViewComponent(IParkingSpaceRepository parkingSpace)
        {
            _parkingSpace = parkingSpace;
        }

        public ParkingSpace[] Invoke()
        {
            return _parkingSpace.GetParkingSpacesToArray();
        }
    }
}
