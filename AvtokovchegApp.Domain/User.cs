using Microsoft.AspNetCore.Identity;

namespace AvtokovchegApp.Domain.Core
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Surname { get; set; }

        public List<Car> Cars { get; set; } = new List<Car>();
        
    }
}
