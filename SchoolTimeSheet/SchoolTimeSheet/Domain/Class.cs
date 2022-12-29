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
        
        public Dictionary<DateOnly, TimeOnly> Times { get; set; }

        public Class(string name, string acronym, int creditCount)
        {
            Name = name;
            Acronym = acronym;
            CreditCount = creditCount;

            Tasks = new List<Task>();
            Times = new Dictionary<DateOnly, TimeOnly>();
        }

        public TimeSpan GetTotalTimeSpent()
        {
            var totalTime = new TimeSpan();
            foreach(TimeOnly time in Times.Values)
            {
                totalTime.Add(time.ToTimeSpan());
            }

            return totalTime;
        }

        /// <summary>
        /// Get total time spent between the start and end date (end date is not included)
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public TimeSpan GetTimeSpent(DateOnly startDate, DateOnly endDate) 
        {
            var totalTime = new TimeSpan();
            while(startDate != endDate)
            {
                if (Times.TryGetValue(startDate, out TimeOnly currentTime))
                {
                    totalTime.Add(currentTime.ToTimeSpan());
                }
                
                startDate.AddDays(1);
            }

            return totalTime;
        }

        public override string ToString()
        {
            return Acronym;
        }
    }
}
