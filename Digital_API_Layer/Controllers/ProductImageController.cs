using Digital_Core_Layer.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Digital_API_Layer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductImageController : ControllerBase
	{
		private readonly IProductImageService _productImageService;

		public ProductImageController(IProductImageService productImageService)
		{
			_productImageService = productImageService;
		}

		[HttpPost("UploadImage")]
		public async Task<IActionResult> UploadImage(Guid productId, List<IFormFile> file)
		{
			var result = await _productImageService.UploadImageAsync(productId, file);
			
			if (!result.Success)
			{
				return BadRequest(result);
			}

			return Ok(result);
		}
	}
}
