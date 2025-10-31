using Digital_Domain_Layer.Entities;
using Digital_Infrastructure_Layer.DTOs;
using Digital_Persistence_Layer.Models;

namespace Digital_Persistence_Layer.Repositories.Interface
{
	public interface IProductRepository
	{
		Task<BaseResponseModel> GetAllProducts();
		Task<BaseResponseModel> GetProductById(Guid id);
		Task<BaseResponseModel> RemoveProduct(Guid id);
		Task<BaseResponseModel> AddProduct(ProductDto productDto);
		Task<BaseResponseModel> UpdateProduct(UpdateProductDto updateProductDto);
	}
}
