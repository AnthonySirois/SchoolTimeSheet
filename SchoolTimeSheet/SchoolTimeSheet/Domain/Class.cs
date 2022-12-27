using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeSheet.Domain
{
    internal class Class
    {
        public string Name { get; set; }
        public string Acronym { get; set; }
        public int CreditCount { get; set; }
        public List<Task> Tasks { get; set; }
    }
}
