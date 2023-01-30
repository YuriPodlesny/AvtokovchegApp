using AvtokovchegApp.Domain;
using System.Threading.Tasks;

namespace Avtokovcheg.Domain.Interfaces
{
    public interface IParkingSpaceRepository : IDisposable
    {
        Task<ParkingSpace[]> GetParkingSpacesToArray();
        Task<ParkingSpace> GetParkingSpace(int namber);
        void EditParkingSpace(ParkingSpace parkingSpace);
    }
}