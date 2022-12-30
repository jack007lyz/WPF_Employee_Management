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

namespace WPF_Employee_Management
{
    /// <summary>
    /// Interaction logic for DepartmentPage.xaml
    /// </summary>
    public partial class DepartmentPage : Window
    {
        public Department Department { get; set; }

        public DepartmentPage()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(txtDepartmentName.Text.Trim() == "" || txtDepartmentName.Text.Trim() == null)
            {
                MessageBox.Show("Please fill the department name");
            }
            else
            {
                using (EmployeeManagementWpfContext db = new EmployeeManagementWpfContext())
                {
                    if (Department != null && Department.Id != 0)
                    {
                        Department department = new Department();
                        department.Id = Department.Id;
                        department.DepartmentName = txtDepartmentName.Text;
                        db.Departments.Update(department);
                        db.SaveChanges();
                        MessageBox.Show("Department was updated");
                    }
                    else
                    {
                        Department department = new Department();
                        department.DepartmentName = txtDepartmentName.Text;
                        db.Departments.Add(department);
                        db.SaveChanges();
                        txtDepartmentName.Clear();
                        MessageBox.Show("Department was added");
                    }
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(Department != null && Department.Id!=0)
            {
                txtDepartmentName.Text = Department.DepartmentName;
            } 
        }
    }
}
