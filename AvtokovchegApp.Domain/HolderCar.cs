using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtokovchegApp.Domain.Core
{
    public class HolderCar : BaseClass
    {
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Surname { get; set; }

        public List<Car> Cars { get; set;} = new ();
    }
}
