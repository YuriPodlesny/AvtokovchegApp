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
    public class BaseRepository<T> : IBaseRepository<T>
        where T : BaseClass
    {
        private AvtokovchegContext _context;

        public BaseRepository(AvtokovchegContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(T entety)
        {
            await _context.Set<T>().AddAsync(entety);
            await _context.SaveChangesAsync();
            return true;
        }

        public void Delete(int id)
        {
            _context.Set<Task<T?>>().Remove(Get(id));
        }

        public async Task<T?> Get(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(p => p.Id == id);
        }

        #region Dispose
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void Save()
        {
            _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified; 
        }
    }
}
