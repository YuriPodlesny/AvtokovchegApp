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

        public void Delete(Agreement agreement)
        {
            db.Agreements.Remove(agreement);
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

        public void Update(Agreement agreement)
        {
            db.Entry(agreement).State = EntityState.Modified;
        }

        public void Create(Agreement agreement)
        {
            db.Agreements.AddAsync(agreement);
        }
    }
}
