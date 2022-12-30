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
using WPF_Employee_Management.DB;

namespace WPF_Employee_Management.Views
{
    /// <summary>
    /// Interaction logic for DepartmentList.xaml
    /// </summary>
    public partial class DepartmentList : UserControl
    {
        public DepartmentList()
        {
            InitializeComponent();
            using (EmployeeManagementWpfContext db = new EmployeeManagementWpfContext())
            {
                List<Department> departments = db.Departments.OrderBy(d=>d.DepartmentName).ToList();
                gridDepartment.ItemsSource = departments;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DepartmentPage departmentPage = new DepartmentPage();
            departmentPage.ShowDialog();
            using (EmployeeManagementWpfContext db = new EmployeeManagementWpfContext())
            {
                List<Department> departments = db.Departments.OrderBy(d => d.DepartmentName).ToList();
                gridDepartment.ItemsSource = departments;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Department dpt = (Department)gridDepartment.SelectedItem;
            DepartmentPage page = new DepartmentPage();
            page.Department = dpt;
            page.ShowDialog();
            using (EmployeeManagementWpfContext db = new EmployeeManagementWpfContext())
            {
                List<Department> departments = db.Departments.OrderBy(d => d.DepartmentName).ToList();
                gridDepartment.ItemsSource = departments;
            }
        }
    }
}
