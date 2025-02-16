﻿using System;
using System.Collections.Generic;

namespace WPF_Employee_Management.DB;

public partial class Salary
{
    public int Id { get; set; }

    public int? EmployeeId { get; set; }

    public int? Amount { get; set; }

    public int? Year { get; set; }

    public int? MonthId { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual SalaryMonth? Month { get; set; }
}
