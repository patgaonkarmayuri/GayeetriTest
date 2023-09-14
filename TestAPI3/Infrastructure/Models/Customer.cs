﻿using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? DateOrBirth { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
