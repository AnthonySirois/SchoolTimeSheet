using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeSheet.Domain
{
    class Program
    {
        public string Name { get; set; }
        public string Acronym { get; set; }
        public List<Session> Sessions { get; set; }

        public Program()
        {
            Sessions = new List<Session>();
        }

        public Program(string name, string acronym) : this()
        {
            Name = name;
            Acronym = acronym;
        }

        public Session GetSession(int year, Season season)
        {
            return Sessions.FirstOrDefault(x => x.Year == year && x.Season == season);
        }

        public void AddSession(Session session)
        {
            Sessions.Add(session);
        }

        public void RemoveSession(Session session) 
        { 
            Sessions.Remove(session);
        }

        public override string ToString()
        {
            return Acronym;
        }
    }
}
