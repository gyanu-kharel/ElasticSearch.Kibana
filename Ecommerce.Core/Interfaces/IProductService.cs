using Ecommerce.Core.Dtos.Products;
using Ecommerce.Data.Models;

namespace Ecommerce.Core.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();

        Product Create(CreateProductDto product);

    }
}
