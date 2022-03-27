using Ecommerce.Core.Interfaces;
using Ecommerce.Data.Models;
using Ecommerce.Data;
using Ecommerce.Core.Dtos.Products;

namespace Ecommerce.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext dbContext;

        public ProductService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Product Create(CreateProductDto data)
        {
            Product product = new()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                CategoryId = data.CategoryId
            };

            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            return dbContext.Products;
        }
    }
}