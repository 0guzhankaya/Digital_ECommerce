using Digital_Persistence_Layer.Models;

namespace Digital_Persistence_Layer.Repositories.Interface
{
	public interface IShoppingCartRepository
	{
		Task<BaseResponseModel> AddToCart(Guid productId);
		Task<BaseResponseModel> GetCartItems();
		Task<BaseResponseModel> RemoveFromCart(Guid productId);
	}
}
