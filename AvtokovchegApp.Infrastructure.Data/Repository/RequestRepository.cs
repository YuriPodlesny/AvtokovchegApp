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
    public class RequestRepository : IRequestRepository
    {
        private readonly AvtokovchegContext db;
        public RequestRepository(AvtokovchegContext db)
        {
            this.db = db;
        }

        public async void Delete(Request request)
        {
            db.Requests.Remove(request);
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

        public async void Update(Request request)
        {
            db.Entry(request).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async void Create(Request request)
        {
            await db.Requests.AddAsync(request);
            await db.SaveChangesAsync();
        }
    }
}
