using api.Application.MappingInterface;
using api.Application.ProductDTOs;
using api.Domain.ProductEntity;


namespace api.Application.MappingImplementation
{
    internal class ProductMapper : IProductMapper
    {
        public ProductDTO MapToDTO(Product product)
        {
            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };
        }

        public Product MapToEntity(CreateProductDTO createDTO)
        {
            return new Product
            {
                Name = createDTO.Name,
                Price = createDTO.Price,
                Stock = createDTO.Stock
            };
        }

        public Product MapToEntity(UpdateProductDTO updateDTO)
        {
            return new Product
            {
                Id = updateDTO.Id,
                Name = updateDTO.Name,
                Price = updateDTO.Price,
                Stock = updateDTO.Stock
            };
        }
    }
}
