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
using System.Windows.Shapes;

namespace TimeSheet.Classes
{
    /// <summary>
    /// Interaction logic for CreateEmployeeWindow.xaml
    /// </summary>
    public partial class CreateEmployeeWindow : Window
    {
        
        public CreateEmployeeWindow()
        {
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(BtnFirstName.Text,out int result)|| BtnFirstName.Text=="")
            MessageBox.Show("Dont insert number", "Error",MessageBoxButton.OK,MessageBoxImage.Warning);
            else if(int.TryParse(BtnLastName.Text, out int numb) || BtnLastName.Text =="")
                MessageBox.Show("Dont insert number", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                Employee emp = new Employee(BtnFirstName.Text, BtnLastName.Text);
                EmployeeController.SerializeEmployee(emp);
                MessageBox.Show($"{emp.FirstName} {emp.LastName} created.", "Created!", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }


        }
    }
}
