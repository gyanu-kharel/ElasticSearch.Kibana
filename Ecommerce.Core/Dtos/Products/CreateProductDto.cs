namespace Ecommerce.Core.Dtos.Products
{
    public record CreateProductDto(string Name, string Description, double Price, int CategoryId);
}