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
    public class AgreementRepository : IAgreementRepository
    {
        private readonly AvtokovchegContext db;
        public AgreementRepository(AvtokovchegContext db)
        {
            this.db = db;
        }

        public async void Delete(Agreement agreement)
        {
            db.Agreements.Remove(agreement);
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

        public async void Update(Agreement agreement)
        {
            db.Entry(agreement).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async void Create(Agreement agreement)
        {
            await db.Agreements.AddAsync(agreement);
            await db.SaveChangesAsync();
        }
    }
}
