using Digital_Core_Layer.Services.Abstract;
using Digital_Infrastructure_Layer.DTOs;
using Digital_Persistence_Layer.Models;
using Digital_Persistence_Layer.Repositories.Interface;

namespace Digital_Core_Layer.Services.Concrete
{
	public class SubCategoryService : ISubCategoryService
	{
		private readonly ISubCategoryRepository _subCategoryRepository;

		public SubCategoryService(ISubCategoryRepository subCategoryRepository)
		{
			_subCategoryRepository = subCategoryRepository;
		}

		public async Task<BaseResponseModel> CreateSubCategory(SubCategoryDto subCategoryDto)
		{
			var result = await _subCategoryRepository.CreateSubCategory(subCategoryDto);
			return result;
		}
	}
}
