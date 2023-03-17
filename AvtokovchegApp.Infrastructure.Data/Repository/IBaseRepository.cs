using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avtokovcheg.Infrastructure.Data
{
    public interface IBaseRepository<T> : IDisposable
        where T : class
    {
        Task<bool> Create(T entety);
        Task<bool> Delete(int id);
        Task<bool> Update(T entity);
        void Save();
        IEnumerable<T> GetAll();
        Task<T?> Get(int id);
    }
}
