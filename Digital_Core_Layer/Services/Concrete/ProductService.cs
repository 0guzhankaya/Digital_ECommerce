using Digital_Core_Layer.Services.Abstract;
using Digital_Infrastructure_Layer.DTOs;
using Digital_Persistence_Layer.Models;
using Digital_Persistence_Layer.Repositories.Interface;

namespace Digital_Core_Layer.Services.Concrete
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;

		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public Task<BaseResponseModel> AddProduct(ProductDto productDto)
		{
			var result = _productRepository.AddProduct(productDto);
			return result;
		}

		public Task<BaseResponseModel> GetAllProducts()
		{
			var result = _productRepository.GetAllProducts();
			return result;
		}

		public Task<BaseResponseModel> GetProductById(Guid id)
		{
			var result = _productRepository.GetProductById(id);
			return result;
		}

		public Task<BaseResponseModel> RemoveProduct(Guid id)
		{
			var result = _productRepository.RemoveProduct(id);
			return result;
		}

		public Task<BaseResponseModel> UpdateProduct(UpdateProductDto updateProductDto)
		{
			var result = _productRepository.UpdateProduct(updateProductDto);
			return result;
		}
	}
}
