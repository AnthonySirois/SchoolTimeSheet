using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeSheet.Domain
{
    internal class Day
    {
        public DateOnly Date { get; set; }
        public List<ClassTime> ClassTimes { get; set; }

    }
}
