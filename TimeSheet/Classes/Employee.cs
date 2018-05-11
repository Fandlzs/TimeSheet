using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Classes
{
    [Serializable]
    public class Employee
    {
        public Employee(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            WorkTimes = new List<WorkTime>();
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public List<WorkTime> WorkTimes { get; private set; }

        public void AddWorkTime(WorkTime wt)
        {
            WorkTimes.Add(wt);
        }

        public List<WorkTime> GetWorkTimes()
        {
            return this.WorkTimes;
        }
    }
}
