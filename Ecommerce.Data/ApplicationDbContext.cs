using Ecommerce.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }    
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Tag> Tags { get; set; }    
        public DbSet<ProductTag> ProductTags { get; set; }
    }
}
