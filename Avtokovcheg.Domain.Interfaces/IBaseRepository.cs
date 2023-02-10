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
        void Create(T entety);
        void Delete(T entity);
        void Update(T entity);
    }
}
