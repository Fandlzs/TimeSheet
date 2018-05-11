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
    /// Interaction logic for ProjectsWindow.xaml
    /// </summary>
    public partial class ProjectsWindow : Window
    {
        public ProjectsWindow()
        {
            InitializeComponent();
        }

        private void BtnCreateProject_Click(object sender, RoutedEventArgs e)
        {
            if(ProjectName.Text!="")
            {
                Projects.AddProject(new Project(ProjectName.Text));
                Projects.SaveProjects();
                MessageBox.Show("PRoject created", "Created", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnRefreshProjects_Click(object sender, RoutedEventArgs e)
        {
            Projects.LoadProjects();
            ProjectList.ItemsSource = null;
            ProjectList.ItemsSource = Projects.GetProjects();
            ProjectList.Columns[0].Width = 114;
        }
    }
}
