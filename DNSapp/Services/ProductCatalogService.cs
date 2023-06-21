using DNSapp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSapp.Services
{
    public class ProductCatalogService
    {
        public ProductCatalogDto Add(ProductCatalogDto productCatalogDto)
        {
            using (DnsMyAssContext db = new DnsMyAssContext())
            {
                ProductCatalog productCatalog = new ProductCatalog()
                {
                    Id = productCatalogDto.Id,
                    Category = productCatalogDto.Category,
                    Product = productCatalogDto.Product,
                    Price = productCatalogDto.Price,
                    ProductCount = productCatalogDto.ProductCount,
                };
                db.ProductCatalogs.Add(productCatalog);
                db.SaveChanges();

                ProductCatalogDto productCatalogDto1 = new ProductCatalogDto()
                {
                    Id = productCatalog.Id,
                    Category = productCatalog.Category,
                    Product = productCatalog.Product,
                    Price = productCatalog.Price,
                    ProductCount = productCatalog.ProductCount != null ? productCatalog.ProductCount : 0,
                };
                return productCatalogDto1;
            }
        }
        private ProductCatalog Get(int Id)
        {
            using (DnsMyAssContext db = new DnsMyAssContext())
            {
                ProductCatalog productCatalog = db.ProductCatalogs.Where(p => p.Id == Id).FirstOrDefault();
                return productCatalog;
            }
        }
        public ProductCatalogDto GetDto(int Id)
        {
            using (DnsMyAssContext db = new DnsMyAssContext())
            {
                ProductCatalog productCatalog = db.ProductCatalogs.Where(p => p.Id == Id).FirstOrDefault();
                ProductCatalogDto productCatalogDto = new ProductCatalogDto()
                {
                    Id = productCatalog.Id,
                    Category = productCatalog.Category,
                    Product = productCatalog.Product,
                    Price = productCatalog.Price,
                    ProductCount = productCatalog.ProductCount != null ? productCatalog.ProductCount : 0,
                };
                return productCatalogDto;
            }
        }
        public List<ProductCatalogDto> GetAllDto()
        {
            using (DnsMyAssContext db = new DnsMyAssContext())
            {
                List<ProductCatalog> productsCatalog = db.ProductCatalogs.ToList();
                List<ProductCatalogDto> productsCatalogDto = new List<ProductCatalogDto>();
                foreach (ProductCatalog productCatalog in productsCatalog)
                {
                    ProductCatalogDto dto = new ProductCatalogDto()
                    {
                        Id = productCatalog.Id,
                        Category = productCatalog.Category,
                        Product = productCatalog.Product,
                        Price = productCatalog.Price,
                        ProductCount = productCatalog.ProductCount != null ? productCatalog.ProductCount : 0,
                    };
                    productsCatalogDto.Add(dto);
                }
                return productsCatalogDto;
            }
        }
        public bool Edit(ProductCatalogDto catalogDto)
        {
            using (DnsMyAssContext db = new DnsMyAssContext())
            {
                ProductCatalog productCatalog = Get(catalogDto.Id);
                if (productCatalog != null)
                {
                    productCatalog.Category = catalogDto.Category;
                    productCatalog.Product = catalogDto.Product;
                    productCatalog.Price = catalogDto.Price;
                    productCatalog.ProductCount = catalogDto.ProductCount;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public void Remove(int Id)
        {
            using (DnsMyAssContext db = new DnsMyAssContext())
            {
                ProductCatalog? productCatalog = db.ProductCatalogs.Where(p => p.Id == Id).FirstOrDefault();
                if(productCatalog != null)
                {
                    db.ProductCatalogs.Remove(productCatalog);
                    db.SaveChanges();
                }
            }
        }
    }
}
