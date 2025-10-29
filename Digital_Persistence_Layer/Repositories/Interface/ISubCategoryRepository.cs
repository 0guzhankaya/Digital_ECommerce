using Digital_Infrastructure_Layer.DTOs;
using Digital_Persistence_Layer.Models;

namespace Digital_Persistence_Layer.Repositories.Interface
{
	public interface ISubCategoryRepository
	{
		Task<BaseResponseModel> CreateSubCategory(SubCategoryDto subCategoryDto);
	}
}
