using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Classes
{
    public static class Projects
    {
        private static List<Project> AllProject { get; set; }
        private static BinaryFormatter formatter;

        public static void AddProject(Project project)
        {
            AllProject.Add(project);
        }

        public static List<Project> GetProjects()
        {
            return AllProject;
        }

        static Projects()
        {
            AllProject = new List<Project>();
            formatter = new BinaryFormatter();
            LoadProjects();
        }

        public static void SaveProjects()
        {
            string[] projectNames = new string[AllProject.Count];
            for(int i = 0;i<projectNames.Length;i++)
            {
                projectNames[i] = AllProject[i].Name;
            }
            File.WriteAllLines("Employees\\Projects.txt", projectNames);
        }

        public static void LoadProjects()
        {
            string[] projectNames = File.ReadAllLines("Employees\\Projects.txt");
            AllProject.Clear();
            foreach(var i in projectNames)
            {
                AllProject.Add(new Project(i));
            }
        }
    }
}
