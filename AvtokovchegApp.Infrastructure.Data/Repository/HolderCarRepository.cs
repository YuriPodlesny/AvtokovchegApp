using Avtokovcheg.Domain.Interfaces;
using AvtokovchegApp.Domain.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AvtokovchegApp.Infrastructure.Data.Repository
{
    public class HolderCarRepository : IHolderCarRepository
    {
        private readonly AvtokovchegContext db;
        public HolderCarRepository(AvtokovchegContext db)
        {
            this.db = db;
        }

        public async void Delete(HolderCar holderCar)
        {
            db.HolderCars.Remove(holderCar);
            await db.SaveChangesAsync();
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

        public async void Update(HolderCar holderCar)
        {
            db.Entry(holderCar).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async void Create(HolderCar holderCar)
        {
            db.HolderCars.AddAsync(holderCar);
            await db.SaveChangesAsync();
        }
    }
}
