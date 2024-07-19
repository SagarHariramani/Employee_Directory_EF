﻿using System;
using System.Collections.Generic;

namespace EmployeeDirectory.Data.Models;

public partial class Location
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
