using System;
using System.Collections.Generic;

namespace WPF_Employee_Management.DB;

public partial class TaskState
{
    public int Id { get; set; }

    public string StateName { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; } = new List<Task>();
}
