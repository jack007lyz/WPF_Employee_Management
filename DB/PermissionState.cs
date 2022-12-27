using System;
using System.Collections.Generic;

namespace WPF_Employee_Management.DB;

public partial class PermissionState
{
    public int Id { get; set; }

    public string StateName { get; set; } = null!;

    public virtual ICollection<Permission> Permissions { get; } = new List<Permission>();
}
