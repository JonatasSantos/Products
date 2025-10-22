using api.Application.MappingInterface;
using api.Application.ProductDTOs;
using api.Application.UseCaseInterface;
using api.Domain.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.UseCaseImplementation
{
    public class ProductService(IProductRepository productRepository, IProductMapper productMapper) : IProductService
    {
        public async Task AddProductAsync(CreateProductDTO productDTO)
        {
            var product = productMapper.MapToEntity(productDTO);
            await productRepository.AddAsync(product);
        }

        public async Task DeleteProductAsync(int id) => await productRepository.DeleteAsync(id);
        
        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await productRepository.GetAllAsync();
            return products.Select(product => productMapper.MapToDTO(product)).ToList();
        }
        public async Task<ProductDTO?> GetProductByIdAsync(int id)
        {
            var product = await productRepository.GetByIdAsync(id);
            return product == null ? null : productMapper.MapToDTO(product);
        }

        public async Task UpdateProductAsync(UpdateProductDTO productDTO)
        {
            var product = productMapper.MapToEntity(productDTO);
            await productRepository.UpdateAsync(product);
        }
    }
}
