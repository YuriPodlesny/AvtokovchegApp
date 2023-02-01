using Avtokovcheg.Domain.Interfaces;
using AvtokovchegApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtokovchegApp.Infrastructure.Data
{
    public class ParkingSpaceRepository : IParkingSpaceRepository
    {
        private readonly AvtokovchegConxext db;

        public ParkingSpaceRepository(AvtokovchegConxext db)
        {
            this.db = db;
        }

        public void EditParkingSpace(ParkingSpace parkingSpace)
        {
            db.Entry(parkingSpace).State = EntityState.Modified;
        }

        public Task<ParkingSpace> GetParkingSpace(int namber)
        {
            return db.ParkingSpaces.FirstAsync(p => p.Namber == namber);
        }

        public ParkingSpace[] GetParkingSpacesToArray()
        {
            return db.ParkingSpaces.ToArray();
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
    }
}
