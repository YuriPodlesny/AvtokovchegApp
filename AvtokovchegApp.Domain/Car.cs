using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtokovchegApp.Domain.Core
{
    public class Car : BaseClass
    {
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public string? Namber { get; set; }
        public int Space { get; set; }

        public string HolderName { get; set; }
        public string HolderPatronymic { get; set; }
        public string HolderSurname { get; set; }

        public int UserId { get; set;}
        public User User { get; set; }

    }
}
