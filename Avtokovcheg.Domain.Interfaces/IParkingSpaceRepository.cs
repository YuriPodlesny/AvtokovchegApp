using AvtokovchegApp.Domain;
using System.Threading.Tasks;

namespace Avtokovcheg.Domain.Interfaces
{
    public interface IParkingSpaceRepository : IDisposable
    {
        public IEnumerable<ParkingSpace> GetAll();
        public ParkingSpace Get(int namber);
        public Task<ParkingSpace> GetAsync(int namber);

        void EditParkingSpace(ParkingSpace parkingSpace);
        ParkingSpace[] GetParkingSpaceFloor(int floor);

        void UpdateFree(int nambeer);
    }
}