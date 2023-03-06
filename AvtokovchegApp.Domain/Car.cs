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
        public string Namber { get; set; }

        public string HolderName { get; set; }
        public string HolderPatronymic { get; set; }
        public string HolderSurname { get; set; }

        public int СontractSpaceId { get; set; }
        public СontractSpace СontractSpace { get; set; }

    }
}
