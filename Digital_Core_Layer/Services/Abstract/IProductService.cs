using Digital_Infrastructure_Layer.DTOs;
using Digital_Persistence_Layer.Models;

namespace Digital_Core_Layer.Services.Abstract
{
	public interface IProductService
	{
		Task<BaseResponseModel> GetAllProducts();
		Task<BaseResponseModel> GetProductById(Guid id);
		Task<BaseResponseModel> RemoveProduct(Guid id);
		Task<BaseResponseModel> AddProduct(ProductDto productDto);
		Task<BaseResponseModel> UpdateProduct(UpdateProductDto updateProductDto);
	}
}
