using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Classes
{
    [Serializable]
    public class WorkTime
    {
        public WorkTime(Project project, DateTime date, int startingHour, int endingHour)
        {
            Project = project;
            Date = date;
            StartingHour = startingHour;
            EndingHour = endingHour;
        }

        public Project Project { get; set; }
        public DateTime Date { get; set; }
        public int StartingHour { get; set; }
        public int EndingHour { get; set; }
        public int SumHour { get { return EndingHour - StartingHour; }  }


    }
}
