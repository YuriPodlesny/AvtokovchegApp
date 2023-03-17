using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtokovchegApp.Domain.Core
{
    /// <summary>
    /// DateStart - дата заключения договора
    /// DateEnd - дата конца периода оплаты
    /// Time - периодичность оплаты договора в днях, периодичность считается от даты заключения договора
    /// </summary>
    public class СontractSpace : BaseClass
    {
        public DateTime DateStart { get; set; }

        private DateTime dateEnd;
        public DateTime DateEnd
        {
            get 
            {
                dateEnd = DateStart.AddDays(Time);
                return dateEnd; 
            }
            set
            {
                dateEnd = value;
            }
        }
        public int Time { get; set; }
        public string NamberContract { get; set; }
        public int NamberSpace { get; set; }
        public decimal Cost { get; set; } 

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
