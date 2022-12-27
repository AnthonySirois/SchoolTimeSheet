using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeSheet.Domain
{
    internal class Week
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set;}
        public List<Day> Days { get; set; }
    }
}
