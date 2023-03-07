using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtokovchegApp.Domain.Core
{
    public class Request : BaseClass
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;

       
    }
}
