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
    public class СontractSpaceRepository : BaseRepository<СontractSpace>, IСontractSpaceRepository
    {
        private readonly AvtokovchegContext _db;
        public СontractSpaceRepository(AvtokovchegContext context, AvtokovchegContext db) : base(context)
        {
            _db = db;
        }

        public IEnumerable<СontractSpace> GetContractByUserId(string userId)
        {
            return  _db.ContractSpaces.Where(x => x.UserId == userId);
        }

    }
}
