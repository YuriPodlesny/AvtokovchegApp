﻿using System;
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

        public int UserId { get; set;}
        public User? User { get; set; }

        public int HolderCarId { get; set; }
        public HolderCar? HolderCar { get; set; }
    }
}
