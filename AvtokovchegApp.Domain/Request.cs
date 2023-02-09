using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtokovchegApp.Domain.Core
{
    public class Request
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public int RenterId { get; set; }
        public Renter? Renter { get; set; }
    }
}
