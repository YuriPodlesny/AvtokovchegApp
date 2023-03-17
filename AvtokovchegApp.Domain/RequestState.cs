using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtokovchegApp.Domain.Core
{
    public enum RequestState
    {
        New = 0,
        UnderConsideration,
        Completed
    }
}
