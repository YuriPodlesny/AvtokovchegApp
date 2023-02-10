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
    public class CarRepository : ICarRepository
    {
        private readonly AvtokovchegContext db;
        public CarRepository(AvtokovchegContext db)
        {
            this.db = db;
        }

        public async void Delete(Car car)
        {
            db.Cars.Remove(car);
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

        public async void Update(Car car)
        {
            db.Entry(car).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async void Create(Car car)
        {
            await db.Cars.AddAsync(car);
            await db.SaveChangesAsync();
        }
    }
}
