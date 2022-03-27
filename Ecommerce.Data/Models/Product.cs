using Ecommerce.Data.Enums;

namespace Ecommerce.Data.Models
{
    public class Product
    {
        public Product()
        {
            Status = (int)ProductStatus.RequireVerification;
        }
        public int Id { get; set; }
        public string? Name { get; set; }   
        public string? Description { get; set; }
        public double Price { get; set; }
        public int Status { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
