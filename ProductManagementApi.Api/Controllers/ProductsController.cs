using Microsoft.AspNetCore.Mvc;
using ProductManagementApi.Application;

namespace ProductManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _productService.GetProductById(id);
            return Ok(product);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductDto productDto)
        {
            _productService.AddProduct(productDto);
            return CreatedAtAction(nameof(Get), new { id = productDto.Id }, productDto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductDto productDto)
        {
            if (id != productDto.Id)
            {
                return BadRequest();
            }

            _productService.UpdateProduct(productDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.SoftDeleteProduct(id);
            return NoContent();
        }
    }
}
