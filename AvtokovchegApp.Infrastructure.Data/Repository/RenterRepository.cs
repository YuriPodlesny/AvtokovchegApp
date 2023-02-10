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
    public class RenterRepository : IRenterRepository
    {
        private readonly AvtokovchegContext db;
        public RenterRepository(AvtokovchegContext db)
        {
            this.db = db;
        }

        public async void Delete(Renter renter)
        {
            db.Renters.Remove(renter);
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

        public async void Update(Renter renter)
        {
            db.Entry(renter).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async void Create(Renter renter)
        {
            await db.Renters.AddAsync(renter);
            await db.SaveChangesAsync();
        }
    }
}
