using AutoMapper;
using Digital_Domain_Layer.Entities;
using Digital_Domain_Layer.Extensions;
using Digital_Infrastructure_Layer.DTOs;
using Digital_Persistence_Layer.AppDbContext;
using Digital_Persistence_Layer.Models;
using Digital_Persistence_Layer.Repositories.Interface;

namespace Digital_Persistence_Layer.Repositories
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		private readonly IMapper _mapper;

		public ProductRepository(ApplicationDbContext context, IMapper mapper) : base(context)
		{
			_mapper = mapper;
		}

		public async Task<BaseResponseModel> AddProduct(ProductDto productDto)
		{

			var action = productDto.Color;
			var actionDescription = action.GetDescription();

			var objMap = _mapper.Map<Product>(productDto);
			objMap.Color = actionDescription;

			Product product = await Add(objMap);

			return new BaseResponseModel
			{
				Success = product != null,
				Message = product != null ? "Product added successfully" : "Failed to add product!",
				Result = product
			};
		}

		public async Task<BaseResponseModel> GetAllProducts()
		{
			IEnumerable<Product> products = await GetAll();
			var objMap = _mapper.Map<IEnumerable<ProductDto>>(products);

			return new BaseResponseModel
			{
				Success = objMap != null,
				Message = objMap != null ? "Products gets successfully" : "Failed to get all products!",
				Result = objMap
			};
		}

		public async Task<BaseResponseModel> GetProductById(Guid id)
		{
			Product product = await GetWhere(x => x.Id == id, x => x.ProductImages);

			var objMap = _mapper.Map<ProductDto>(product);

			return new BaseResponseModel
			{
				Success = objMap != null,
				Message = objMap != null ? "Product gets successfully" : "Failed to get product!",
				Result = objMap
			};

		}

		public async Task<BaseResponseModel> RemoveProduct(Guid id)
		{
			await Delete(id);

			return new BaseResponseModel
			{
				Success = true,
				Message = "Product removed successfully",
				Result = null
			};
		}

		public async Task<BaseResponseModel> UpdateProduct(UpdateProductDto updateProductDto)
		{
			var objMap = _mapper.Map<Product>(updateProductDto);
			var result = await Update(updateProductDto.ProductId, objMap);

			return new BaseResponseModel
			{
				Success = result != null,
				Message = result != null ? "Product updated successfully" : "Failed to update product!",
				Result = result
			};
		}
	}
}
