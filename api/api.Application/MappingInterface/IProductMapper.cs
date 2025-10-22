using api.Application.ProductDTOs;
using api.Domain.ProductEntity;

namespace api.Application.MappingInterface
{
    public interface IProductMapper
    {
        ProductDTO MapToDTO(Product product);
        Product MapToEntity(CreateProductDTO createDTO);
        Product MapToEntity(UpdateProductDTO updateDTO);
    }
}
