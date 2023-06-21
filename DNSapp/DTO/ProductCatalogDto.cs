using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSapp.DTO
{
    public class ProductCatalogDto
    {
        public int Id { get; set; }

        public string? Category { get; set; }

        public string? Product { get; set; }

        public decimal Price { get; set; }

        public int? ProductCount { get; set; }
    }
}
