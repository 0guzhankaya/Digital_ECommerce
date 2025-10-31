using Digital_Core_Layer.Services.Abstract;
using Digital_Persistence_Layer.Models;
using Digital_Persistence_Layer.Repositories.Interface;
using Microsoft.AspNetCore.Http;

namespace Digital_Core_Layer.Services.Concrete
{
	public class ProductImageService : IProductImageService
	{
		private readonly IProductImageRepository _productImageRepository;

		public ProductImageService(IProductImageRepository productImageRepository)
		{
			_productImageRepository = productImageRepository;
		}

		public async Task<BaseResponseModel> UploadImageAsync(Guid productId, List<IFormFile> file)
		{
			var result = await _productImageRepository.UploadImageAsync(productId, file);
			return result;
		}
	}
}
