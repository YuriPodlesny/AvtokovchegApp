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
    /// DateEnd - срок договора в днях (если договор не бессрочный)
    /// Time - периодичность оплаты договора в днях, периодичность считается от даты заключения договора
    /// </summary>
    public class СontractSpace : BaseClass
    {
        public DateTime DateStart { get; set; }
        public int? DateEnd { get; set; }
        public int Time { get; set; }
        public string NamberContract { get; set; }
        public int NamberSpace { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
