using System;
using System.Collections.Generic;

namespace DNSapp;

public partial class ProductCatalog
{
    public int Id { get; set; }

    public string? Category { get; set; }

    public string? Product { get; set; }

    public decimal Price { get; set; }

    public int? ProductCount { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
