using Digital_Core_Layer.Services.Abstract;
using Digital_Infrastructure_Layer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Digital_API_Layer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MainCategoryController : ControllerBase
	{
		private readonly IMainCategoryService _mainCategoryService;

		public MainCategoryController(IMainCategoryService mainCategoryService)
		{
			_mainCategoryService = mainCategoryService;
		}

		[HttpPost]
		public async Task<IActionResult> CreateMainCategory([FromBody] MainCategoryDto mainCategoryDto)
		{
			var result = await _mainCategoryService.CreateMainCategory(mainCategoryDto);

			if (!result.Success)
			{
				return BadRequest(result);
			}

			return Ok(result);
		}

		[HttpGet]
		public async Task<IActionResult> GetMainCategories()
		{
			var result = await _mainCategoryService.GetMainCategories();

			if (!result.Success)
			{
				return NotFound(result);
			}

			return Ok(result);
		}
	}
}
