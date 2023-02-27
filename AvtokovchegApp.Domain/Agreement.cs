﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtokovchegApp.Domain.Core
{
    public class Agreement : BaseClass
    {
        public string NamberAgreement { get; set; }
        public DateTime DateAgreement { get; set; }
        public int TimeAgreement { get; set; }
        
        public int UserId { get; set; }
        public User? User { get; set; }

        public int NamberId { get; set; }
        public ParkingSpace? ParkingSpace { get; set; }


    }
}
