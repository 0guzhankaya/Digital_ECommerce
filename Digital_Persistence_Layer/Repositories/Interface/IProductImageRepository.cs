using Digital_Persistence_Layer.Models;
using Microsoft.AspNetCore.Http;

namespace Digital_Persistence_Layer.Repositories.Interface
{
	public interface IProductImageRepository
	{
		Task<BaseResponseModel> UploadImageAsync(Guid productId, List<IFormFile> file);
	}
}
