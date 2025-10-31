using AutoMapper;
using Digital_Domain_Layer.Entities;
using Digital_Infrastructure_Layer.DTOs;

namespace Digital_Persistence_Layer.MappingProfiles
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			CreateMap<MainCategoryDto, MainCategory>().ReverseMap();
			CreateMap<SubCategoryDto, SubCategory>().ReverseMap();
			CreateMap<ProductDto, Product>().ReverseMap();
			CreateMap<GetProductDto, Product>().ReverseMap();
			CreateMap<UpdateProductDto, Product>().ReverseMap();
		}
	}
}
