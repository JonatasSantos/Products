using api.Application.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.UseCaseInterface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO?> GetProductByIdAsync(int id);
        Task AddProductAsync(CreateProductDTO createDTO);
        Task UpdateProductAsync(UpdateProductDTO updateDTO);
        Task DeleteProductAsync(int id);
    }
}
