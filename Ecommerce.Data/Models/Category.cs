namespace Ecommerce.Data.Models
{
    public class Category
    {
    
        public Category()
        {
            CreatedAt = DateTime.Now;
            IsActive = true;
        }
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; private set; }
    }
}
