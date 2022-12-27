using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.NetworkOperators;

namespace SchoolTimeSheet.Domain
{
    internal class Session
    {
        public int Year { get; set; }
        public Season season { get; set; }
        public List<Week> Weeks { get; set; }
        public List<Class> Classes { get; set; }
    }
}
