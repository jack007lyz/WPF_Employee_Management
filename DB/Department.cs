using System;
using System.Collections.Generic;

namespace WPF_Employee_Management.DB;

public partial class Department
{
    public int Id { get; set; }

    public string DepartmentName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();

    public virtual ICollection<Position> Positions { get; } = new List<Position>();
}
