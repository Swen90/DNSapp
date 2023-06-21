using System;
using System.Collections.Generic;

namespace DNSapp;

public partial class Order
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int CustomerId { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? ProductCount { get; set; }

    public decimal Price { get; set; }

    public virtual UserInfo Customer { get; set; } = null!;

    public virtual ProductCatalog Product { get; set; } = null!;
}
