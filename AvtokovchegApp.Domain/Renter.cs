using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtokovchegApp.Domain.Core
{
    public class Renter : BaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Surname { get; set; }
        public string PhoneNamber { get; set; }

        public List<ParkingSpace> ParkingSpaces { get; set; } = new ();
        public List<Request> Requests { get; set; } = new ();
        public List<Car> Cars { get; set; } = new ();
        public List<Agreement> Agreements { get; set; } = new ();
    }
}
