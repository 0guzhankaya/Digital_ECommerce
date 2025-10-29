using Digital_Infrastructure_Layer.DTOs;
using Digital_Persistence_Layer.Models;

namespace Digital_Persistence_Layer.Repositories.Interface
{
	public interface IMainCategoryRepository
	{
		Task<BaseResponseModel> CreateMainCategory(MainCategoryDto mainCategoryDto);
		Task<BaseResponseModel> GetAllMainCategories();
	}
}
