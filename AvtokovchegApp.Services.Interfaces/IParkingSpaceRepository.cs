using AvtokovchegApp.Domain;
using System.Threading.Tasks;

namespace AvtokovchegApp.Services.Interfaces
{
    public interface IParkingSpaceRepository : IDisposable
    {
        IEnumerable<ParkingSpace> GetAll();
        Task<ParkingSpace> Get(int namber);
        Task<bool> Update(ParkingSpace parkingSpace);
        ParkingSpace[] GetParkingSpaceByFloor(int floor);
    }
}