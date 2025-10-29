using Digital_Core_Layer.Services.Abstract;
using Digital_Infrastructure_Layer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Digital_API_Layer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SubCategoryController : ControllerBase
	{
		private readonly ISubCategoryService _subCategoryService;

		public SubCategoryController(ISubCategoryService subCategoryService)
		{
			_subCategoryService = subCategoryService;
		}

		[HttpPost]
		public async Task<IActionResult> CreateSubCategory([FromBody] SubCategoryDto subCategoryDto)
		{
			var response = await _subCategoryService.CreateSubCategory(subCategoryDto);

			if (!response.Success)
			{
				return BadRequest(response);
			}

			return Ok(response);
		}
	}
}
