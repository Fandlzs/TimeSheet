using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TimeSheet.Classes
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ReportWindow()
        {
            InitializeComponent();
            for (int i = 1; i < 13; i++)
            {
                MonthBox.Items.Add(i);
            }

        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            foreach (var i in EmployeeController.Employees)
            {
                EmployeeBox.Items.Add($"{i.FirstName} {i.LastName}");
            }
        }

        private void BtnGetReport_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeBox.SelectedItem == null)
            {
                MessageBox.Show("No employee selected", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (MonthBox.SelectedItem == null)
            {
                MessageBox.Show("No month selected", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string[] name = EmployeeBox.SelectedItem.ToString().Split(' ');
            Employee emp = EmployeeController.Employees.Where(x => x.FirstName == name[0] && x.LastName == name[1]).First();


            string date = DateTime.Now.ToString();

            date = date.Replace(".", "");
            date = date.Replace(":", "");
            date = date.Replace(" ", "");

            int sumhour = emp.WorkTimes.Where(x => x.Date.Month == int.Parse(MonthBox.SelectedItem.ToString())).Sum(x => x.SumHour);
            string path = $"Employees\\{emp.FirstName}_{emp.LastName}_Report_{date}.txt";
            if (HungarianCheck.IsChecked == false)
            {
                List<string> report = new List<string>();
                report.Add("Timesheet");
                report.Add("\n");
                report.Add($"{emp.FirstName} {emp.LastName} worked {sumhour} hour in the {MonthTranslator.GetMonth(int.Parse(MonthBox.SelectedItem.ToString()), false)} of 2018.");
                report.Add("\n");
                report.Add("Itemize as projects:");
                report.Add("\n");

                List<Project> projects = new List<Project>();
                foreach (var i in emp.WorkTimes)
                {
                    if (!projects.Contains(i.Project))
                    {
                        projects.Add(i.Project);
                    }
                }
                int[] hours = new int[projects.Count];
                int counter = 0;
                foreach (var i in projects)
                {
                    hours[counter] = emp.WorkTimes.Where(x => x.Project.Name == i.Name && x.Date.Month == int.Parse(MonthBox.SelectedItem.ToString())).Sum(x => x.SumHour);

                    counter++;
                }
                report.Add($"{"Project",10}{"Hour",15}");
                for (int i = 0; i < projects.Count; i++)
                {
                    report.Add($"{projects[i].Name,10}{hours[i],15}");
                }


                string[] result = report.ToArray();
                File.WriteAllLines(path, result);
                MessageBox.Show("Report created!", "Created!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                List<string> report = new List<string>();
                report.Add("Munkaidő nyilvántartás");
                report.Add("\n");
                report.Add($"{emp.FirstName} {emp.LastName} 2018 {MonthTranslator.GetMonth(int.Parse(MonthBox.SelectedItem.ToString()), true)} hónapjában {sumhour} órát dolgozott.");
                report.Add("\n");
                report.Add("Projektenként részletezve:");
                report.Add("\n");

                List<Project> projects = new List<Project>();
                foreach (var i in emp.WorkTimes)
                {
                    if (!projects.Contains(i.Project))
                    {
                        projects.Add(i.Project);
                    }
                }
                int[] hours = new int[projects.Count];
                int counter = 0;
                foreach (var i in projects)
                {
                    hours[counter] = emp.WorkTimes.Where(x => x.Project.Name == i.Name && x.Date.Month == int.Parse(MonthBox.SelectedItem.ToString())).Sum(x => x.SumHour);

                    counter++;
                }
                report.Add($"{"Projekt",10}{"Óra",15}");
                for (int i = 0; i < projects.Count; i++)
                {
                    report.Add($"{projects[i].Name,10}{hours[i],15}");
                }


                string[] result = report.ToArray();
                File.WriteAllLines(path, result);
                MessageBox.Show("Report created!", "Created!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

       
    }
}
