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

        public string UserName { get; set; }
        public string UserPatronymiс { get; set;}
        public string UserSurname { get; set; }

        public string? HolderName { get; set; }
        public string? HolderPatronymiс { get; set; }
        public string? HolderSurname { get; set; }

        public string CarBrend { get; set; }
        public string CarModel { get; set; }
    }
}
