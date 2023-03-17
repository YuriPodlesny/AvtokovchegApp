﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtokovchegApp.Domain.Core
{
    public class Order
    {
        public string Id { get; set; }
        public DateTime? Date { get; set; }
        public decimal Sum { get; set; }
        public string Sender { get; set; }
        public string Operation_Id { get; set; }
        public decimal Amount { get; set; }
        public decimal? WithdrawAmount { get; set;}
        public int UserId { get; set; }

        public int СontractSpaceId { get; set; }
        public СontractSpace ContractSpace { get; set; }
    }
}
