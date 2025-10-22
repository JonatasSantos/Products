using api.Application.ProductDTOs;
using api.Application.UseCaseInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDTO createProductDTO)
        {
            await productService.AddProductAsync(createProductDTO);
            return CreatedAtAction(nameof(GetById), new { id = createProductDTO.Name }, createProductDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDTO updateProductDTO)
        {
            if (id != updateProductDTO.Id)
            {
                return BadRequest();
            }
            await productService.UpdateProductAsync(updateProductDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
