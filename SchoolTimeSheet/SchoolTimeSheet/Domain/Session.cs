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
        public Season Season { get; set; }
        public List<Class> Classes { get; set; }

        public Session() 
        {
            Year = DateTime.Now.Year;
            Season = Season.Fall;

            Classes = new List<Class>();
        }

        public Session(int year, Season season) : this()
        {
            Year = year;
            Season = season;
        }

        public void AddClass(Class c)
        {
            Classes.Add(c);
        }

        public override string ToString()
        {
            return $"{Year}-{Season}";
        }
    }
}
