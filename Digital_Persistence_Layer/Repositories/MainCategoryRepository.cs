using Digital_Domain_Layer.Entities;
using Digital_Infrastructure_Layer.DTOs;
using Digital_Persistence_Layer.AppDbContext;
using Digital_Persistence_Layer.Models;
using Digital_Persistence_Layer.Repositories.Interface;

namespace Digital_Persistence_Layer.Repositories
{
	public class MainCategoryRepository : Repository<MainCategory>, IMainCategoryRepository
	{
		public MainCategoryRepository(ApplicationDbContext context) : base(context)
		{
		}

		public async Task<BaseResponseModel> CreateMainCategory(MainCategoryDto mainCategoryDto)
		{
			var result = await Add(new MainCategory
			{
				CategoryName = mainCategoryDto.CategoryName,
				CategoryDescription = mainCategoryDto.CategoryDescription
			});

			if (result is null)
			{
				return new BaseResponseModel
				{
					Success = false,
					Message = "An error occurred while creating the main category!"
				};
			}

			return new BaseResponseModel
			{
				Success = true,
				Message = "Main Category created successfully.",
				Result = result
			};
		}

		public async Task<BaseResponseModel> GetAllMainCategories()
		{
			var result = await GetWithIncludeProperties(x => x.SubCategories);

			if (result is null || !result.Any())
			{
				return new BaseResponseModel
				{
					Success = false,
					Message = "No main categories found."
				};
			}

			return new BaseResponseModel
			{
				Success = true,
				Message = "Main categories retrieved successfully.",
				Result = result
			};
		}
	}
}
