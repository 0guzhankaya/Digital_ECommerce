using Digital_Infrastructure_Layer.DTOs;
using Digital_Persistence_Layer.Models;

namespace Digital_Core_Layer.Services.Abstract
{
	public interface IMainCategoryService
	{
		Task<BaseResponseModel> CreateMainCategory(MainCategoryDto mainCategoryDto);
		Task<BaseResponseModel> GetMainCategories();
	}
}
