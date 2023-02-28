using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avtokovcheg.Domain.Interfaces
{
    public interface IBaseRepository<T> : IDisposable
        where T : class
    {
        Task<bool> Create(T entety);
        void Delete(int id);
        void Update(T entity);
        void Save();
        IEnumerable<T> GetAll();
        Task<T?> Get(int id);
    }
}
