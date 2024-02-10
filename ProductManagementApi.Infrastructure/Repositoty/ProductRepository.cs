using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProductManagementApi.Domain;

namespace ProductManagementApi.Infrastructure
{
    public class ProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public Product GetById(int id)
        {
            return _context.Products.SingleOrDefault(p => p.Id == id);
        }

        public IQueryable<Product> GetAll()
        {
            return _context.Products.AsQueryable();
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void SoftDelete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                product.Status = ProductStatus.Inactive;
                _context.SaveChanges();
            }
        }
    }
}
