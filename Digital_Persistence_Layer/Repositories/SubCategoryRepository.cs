using AutoMapper;
using Digital_Domain_Layer.Entities;
using Digital_Infrastructure_Layer.DTOs;
using Digital_Persistence_Layer.AppDbContext;
using Digital_Persistence_Layer.Models;
using Digital_Persistence_Layer.Repositories.Interface;

namespace Digital_Persistence_Layer.Repositories
{
	public class SubCategoryRepository : Repository<SubCategory>, ISubCategoryRepository
	{
		private readonly IMapper _mapper;
		public SubCategoryRepository(ApplicationDbContext context, IMapper mapper) : base(context)
		{
			_mapper = mapper;
		}

		public async Task<BaseResponseModel> CreateSubCategory(SubCategoryDto subCategoryDto)
		{
			var objMap = _mapper.Map<SubCategory>(subCategoryDto);
			var result = await Add(objMap);

			if (result is null)
			{
				return new BaseResponseModel
				{
					Success = false,
					Message = "Failed to create Sub Category!"
				};
			}

			return new BaseResponseModel
			{
				Success = true,
				Message = "Sub Category created successfully.",
				Result = result
			};
		}
	}
}
