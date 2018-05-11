using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
    /// Interaction logic for WorkTimeCreatorWindow.xaml
    /// </summary>
    public partial class WorkTimeCreatorWindow : Window
    {
        
        private List<Project> projects { get; set; }
        public WorkTimeCreatorWindow(List<Employee> employees)
        {
            InitializeComponent();
            EmployeeController.Employees = employees;
        }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            foreach(var i in Projects.GetProjects())
            {
                ProjectsList.Items.Add(i.Name);
            }
            foreach (var i in EmployeeController.Employees)
            {
                EmployeePicker.Items.Add($"{i.FirstName} {i.LastName}");
            }

        }

        private void BtnWorkingHourSave_Click(object sender, RoutedEventArgs e)
        {
            if(ProjectsList.SelectedItem==null)
            {
                MessageBox.Show("No project selected", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(EmployeePicker.SelectedItem==null)
            {
                MessageBox.Show("No employee selected", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(WorkDatePicker.SelectedDate==null|| WorkDatePicker.SelectedDate>DateTime.Now)
            {
                MessageBox.Show("No date selected", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(!int.TryParse(StartingHourBox.Text,out int startingHour)||!int.TryParse(EndingHourBox.Text,out int endingHour))
            {
                MessageBox.Show("No hour selected", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(startingHour>24||startingHour<0||endingHour>24||startingHour<0||(endingHour<=startingHour))
            {
                MessageBox.Show("Wrong hours", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Project project = Projects.GetProjects().Where(x => x.Name == ProjectsList.SelectedItem.ToString()).First();

            WorkTime wt = new WorkTime(project,(DateTime)WorkDatePicker.SelectedDate, startingHour, endingHour);
            string[] name = EmployeePicker.SelectedItem.ToString().Split(' ');
            Employee emp = EmployeeController.Employees.Where(x => x.FirstName == name[0] && x.LastName == name[1]).First();
            emp.AddWorkTime(wt);
            EmployeeController.SerializeEmployee(emp);
            MessageBox.Show("WorkTime saved!", "Saved", MessageBoxButton.OK);
        }
    }
}
