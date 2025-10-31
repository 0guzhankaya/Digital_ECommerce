using Digital_Domain_Layer.Entities;
using Digital_Persistence_Layer.AppDbContext;
using Digital_Persistence_Layer.Models;
using Digital_Persistence_Layer.Repositories.Interface;
using Microsoft.AspNetCore.Http;

namespace Digital_Persistence_Layer.Repositories
{
	public class ProductImageRepository : Repository<ProductImage>, IProductImageRepository
	{
		public ProductImageRepository(ApplicationDbContext context) : base(context)
		{
		}

		public async Task<BaseResponseModel> UploadImageAsync(Guid productId, List<IFormFile> file)
		{
			if (file.Count == 0 || file is null)
			{
				return new BaseResponseModel()
				{
					Success = false,
					Message = "No files uploaded."
				};

			}

			var uploadDirectory = Path.Combine("wwwroot", "images");
			if (!Directory.Exists(uploadDirectory))
			{
				Directory.CreateDirectory(uploadDirectory);
			}

			var uploadImages = new List<ProductImage>();

			foreach (var item in file)
			{
				var filePath = Path.Combine(uploadDirectory, item.FileName);

				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await item.CopyToAsync(stream);
				}

				uploadImages.Add(new ProductImage
				{
					ProductId = productId,
					ImageUrl = filePath
				});
			}

			var result = await AddRange(uploadImages);

			if (result is not null)
			{
				return new BaseResponseModel
				{
					Success = false,
					Message = "Failed to upload image!"
				};

			}

			return new BaseResponseModel
			{
				Success = true,
				Message = "Image uploaded successfully.",
				Result = result
			};
		}
	}
}
