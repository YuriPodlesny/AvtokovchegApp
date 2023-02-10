using AvtokovchegApp.Domain.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtokovchegApp.Infrastructure.Data.Repository
{
    public class CarRepository
    {
        private readonly AvtokovchegContext db;
        public CarRepository(AvtokovchegContext db)
        {
            this.db = db;
        }

        public void Delete(Car car)
        {
            db.Cars.Remove(car);
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

        public void Update(Car car)
        {
            db.Entry(car).State = EntityState.Modified;
        }

        public void Create(Car car)
        {
            db.Cars.AddAsync(car);
        }
    }
}
