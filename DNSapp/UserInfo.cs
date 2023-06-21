using System;
using System.Collections.Generic;

namespace DNSapp;

public partial class UserInfo
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? SecondName { get; set; }

    public int? PhoneNumber { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
