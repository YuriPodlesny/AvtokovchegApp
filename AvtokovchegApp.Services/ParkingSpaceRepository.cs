using AvtokovchegApp.Domain;
using AvtokovchegApp.Infrastructure.Data;
using AvtokovchegApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AvtokovchegApp.Services
{
    public class ParkingSpaceRepository : IParkingSpaceRepository
    {
        private readonly AvtokovchegContext db;

        public ParkingSpaceRepository(AvtokovchegContext db)
        {
            this.db = db;
        }
        #region Dispose
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
        public async Task<bool> Update(ParkingSpace parkingSpace)
        {
            db.Entry(parkingSpace).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<ParkingSpace> Get(int namber)
        {
            return await db.ParkingSpaces.FirstOrDefaultAsync(p => p.Namber == namber);
        }

        public IEnumerable<ParkingSpace> GetAll()
        {
            return db.ParkingSpaces.AsQueryable();
        }

        public ParkingSpace[] GetParkingSpaceByFloor(int floor)
        {
            return db.ParkingSpaces.Where(p => p.Floor == floor).ToArray();
        }
    }
}
