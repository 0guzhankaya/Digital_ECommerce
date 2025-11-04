using Digital_Domain_Layer.Entities;
using Digital_Persistence_Layer.AppDbContext;
using Digital_Persistence_Layer.Models;
using Digital_Persistence_Layer.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Digital_Persistence_Layer.Repositories
{
	public class ShoppingCartRepository : Repository<Cart>, IShoppingCartRepository
	{

		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly string userId;
		public ShoppingCartRepository(ApplicationDbContext context) : base(context)
		{
			userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
		}

		public async Task<BaseResponseModel> AddToCart(Guid productId)
		{
			var cart = await GetWhere(x => x.UserId == userId, x => x.Products);

			if (cart is null)
			{
				var newCart = new Cart
				{
					UserId = userId,
				};

				var product = new Product
				{
					Id = productId
				};

				newCart.Products.Add(product);
				var result = await Add(newCart);

				if (result is null)
				{
					return new BaseResponseModel
					{
						Success = false,
						Message = "Failed to create cart and add product!"
					};
				}

				return new BaseResponseModel
				{
					Success = true,
					Message = "Cart created and product added successfully.",
					Result = result
				};
			}
			else
			{
				var product = new Product
				{
					Id = productId,
				};

				cart.Products.Add(product);
				var result = await Update(cart.Id, cart);

				if (result is null)
				{
					return new BaseResponseModel
					{
						Success = false,
						Message = "Failed to create cart and add product!"
					};
				}

				return new BaseResponseModel
				{
					Success = true,
					Message = "Product added to cart successfully.",
					Result = result
				};
			}
		}

		public async Task<BaseResponseModel> GetCartItems()
		{
			var result = await GetWhere(x => x.UserId == userId, x => x.Products);
			if (result is null)
			{
				return new BaseResponseModel
				{
					Success = false,
					Message = "No items in cart."
				};
			}
			return new BaseResponseModel
			{
				Success = true,
				Message = "Cart items retrieved successfully.",
				Result = result
			};
		}

		public async Task<BaseResponseModel> RemoveFromCart(Guid productId)
		{
			var cart = await GetWhere(x => x.UserId == userId, x => x.Products);

			if (cart is not null)
			{
				var product = cart.Products.FirstOrDefault(p => p.Id == productId);

				if (product is not null)
				{
					cart.Products.Remove(product);
					var result = Update(cart.Id, cart).Result;

					if (result is null)
					{
						return new BaseResponseModel
						{
							Success = false,
							Message = "Failed to remove product from cart!"
						};
					}

					return new BaseResponseModel
					{
						Success = true,
						Message = "Product removed from cart successfully.",
						Result = result
					};
				}

				return new BaseResponseModel
				{
					Success = false,
					Message = "Product not found in cart!"
				};
			}

			return new BaseResponseModel
			{
				Success = false,
				Message = "Cart not found!"
			};
		}
	}
}
