using Digital_Core_Layer.Services.Abstract;
using Digital_Infrastructure_Layer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Digital_API_Layer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpPost("Create")]
		public async Task<IActionResult> CreateProduct(ProductDto productDto)
		{
			var result = await _productService.AddProduct(productDto);
			return Ok(result);
		}

		[HttpGet("GetAll")]
		public async Task<IActionResult> GetAllProducts()
		{
			var result = await _productService.GetAllProducts();
			return Ok(result);
		}

		[HttpGet("GetById")]
		public async Task<IActionResult> GetProductById(Guid id)
		{
			var result = await _productService.GetProductById(id);
			return Ok(result);
		}

		[HttpDelete("Delete")]
		public async Task<IActionResult> DeleteProduct(Guid id)
		{
			var result = await _productService.RemoveProduct(id);
			return Ok(result);
		}

		[HttpPut("Update")]
		public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
		{
			var result = await _productService.UpdateProduct(updateProductDto);
			return Ok(result);
		}
	}
}
