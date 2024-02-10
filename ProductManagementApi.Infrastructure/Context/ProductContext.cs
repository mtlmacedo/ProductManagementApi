using Microsoft.EntityFrameworkCore;
using ProductManagementApi.Domain;

namespace ProductManagementApi.Infrastructure
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
    }
}