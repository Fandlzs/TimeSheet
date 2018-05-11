using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Classes
{
    public static class EmployeeController
    {
        public static List<Employee> Employees { get; set; }
        private static BinaryFormatter formatter;
        

        static EmployeeController()
        {
            Employees = new List<Employee>();
            formatter = new BinaryFormatter();
        }

        public static void SerializeEmployee(Employee employee)
        {
            

            using (FileStream file = File.Create($"Employees\\{employee.FirstName}_{employee.LastName}.bin"))
            {
                formatter.Serialize(file, employee);
                
            }
                
            

        }

        public static void DeserializeEmployees()
        {
            Employees.Clear();
            
            string[] files = Directory.GetFiles("Employees");
            foreach (string i in files)
            {
                if (!i.Contains("Projects") && !i.Contains("WorkTimes") && !i.Contains("Report"))
                {
                    using (FileStream file = File.OpenRead(i))
                    { 
                        Employee emp = formatter.Deserialize(file) as Employee;
                        Employees.Add(emp);
                    }
                }
            }
        }
    }
}
