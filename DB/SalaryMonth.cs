using System;
using System.Collections.Generic;

namespace WPF_Employee_Management.DB;

public partial class SalaryMonth
{
    public int Id { get; set; }

    public string? MonthName { get; set; }

    public virtual ICollection<Salary> Salaries { get; } = new List<Salary>();
}
