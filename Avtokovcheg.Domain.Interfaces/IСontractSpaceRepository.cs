using AvtokovchegApp.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avtokovcheg.Domain.Interfaces
{
    public interface IСontractSpaceRepository : IBaseRepository<СontractSpace>
    {
        IEnumerable<СontractSpace> GetContractByUserId(string userId);
    }
}
