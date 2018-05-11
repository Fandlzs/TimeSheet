using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimeSheet.Classes;

namespace TimeSheet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void BtnCreateEmployee_Click(object sender, RoutedEventArgs e)
        {
            CreateEmployeeWindow window2 = new CreateEmployeeWindow();
            window2.Show();
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            EmployeeController.DeserializeEmployees();
            ListOfEmployees.ItemsSource = null;
            ListOfEmployees.ItemsSource = EmployeeController.Employees;
            ListOfEmployees.Columns[2].Visibility = Visibility.Hidden;
            ListOfEmployees.Columns[0].Width = 132;
            ListOfEmployees.Columns[1].Width = 132;
        }

        private void BtnProjectCreate_Click(object sender, RoutedEventArgs e)
        {
            ProjectsWindow win3 = new ProjectsWindow();
            win3.Show();
        }

        private void BtnWorkTimeCreate_Click(object sender, RoutedEventArgs e)
        {
            WorkTimeCreatorWindow win4 = new WorkTimeCreatorWindow(EmployeeController.Employees);
            win4.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BtnRefresh_Click(sender,e);
        }

        private void BtnReports_Click(object sender, RoutedEventArgs e)
        {
            ReportWindow win5 = new ReportWindow();
            win5.Show();
        }
    }
}
