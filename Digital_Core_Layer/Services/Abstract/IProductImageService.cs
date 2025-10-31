using Digital_Persistence_Layer.Models;
using Microsoft.AspNetCore.Http;

namespace Digital_Core_Layer.Services.Abstract
{
	public interface IProductImageService
	{
		Task<BaseResponseModel> UploadImageAsync(Guid productId, List<IFormFile> file);
	}
}
