using Microsoft.EntityFrameworkCore;
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
using WPF_Employee_Management.ViewModels;

namespace WPF_Employee_Management.Views
{
    /// <summary>
    /// Interaction logic for PositionList.xaml
    /// </summary>
    public partial class PositionList : UserControl
    {
        EmployeeManagementWpfContext _context = new EmployeeManagementWpfContext();

        public PositionList()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var list = _context.Positions.Include(x => x.Department).Select(y => new
            {
                positionId = y.Id,
                positionName = y.PositionName,
                departmentId = y.DepartmentId,
                departmentName = y.Department.DepartmentName,
            }).OrderBy(x=>x.positionId).ToList();

            List<PositionModel> positionModels = new List<PositionModel>(); 
            foreach(var position in list)
            {
                PositionModel model = new PositionModel();
                model.Id = position.positionId;
                model.PositionName = position.positionName;
                model.DepartmentName = position.departmentName;
                model.DepartmentId = position.departmentId;
                positionModels.Add(model);
            }

            gridPosition.ItemsSource = positionModels;
        }
    }
}
