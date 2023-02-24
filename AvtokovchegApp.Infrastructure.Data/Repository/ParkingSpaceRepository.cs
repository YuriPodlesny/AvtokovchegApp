using Avtokovcheg.Domain.Interfaces;
using AvtokovchegApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtokovchegApp.Infrastructure.Data.Repository
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
        public async void EditParkingSpace(ParkingSpace parkingSpace)
        {
            db.Entry(parkingSpace).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public ParkingSpace Get(int namber)
        {
            return db.ParkingSpaces.First(p => p.Namber == namber);
        }

        public async Task<ParkingSpace> GetAsync(int namber)
        {
            return await db.ParkingSpaces.FirstAsync(p => p.Namber == namber);
        }


        public IEnumerable<ParkingSpace> GetAll()
        {
            return db.ParkingSpaces.AsQueryable();
        }

        public ParkingSpace[] GetParkingSpaceFloor(int floor)
        {
            return db.ParkingSpaces.Where(p => p.Floor == floor).ToArray();
        }

        public void UpdateFree(int nambeer)
        {
            var space = Get(nambeer);
            space.IsFree = false;
            EditParkingSpace(space);
        }
    }
}
