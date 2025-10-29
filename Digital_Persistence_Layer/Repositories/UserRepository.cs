using Digital_Domain_Layer.Entities;
using Digital_Infrastructure_Layer.Extensions;
using Digital_Infrastructure_Layer.Models;
using Digital_Persistence_Layer.AppDbContext;
using Digital_Persistence_Layer.Models;
using Digital_Persistence_Layer.Repositories.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Digital_Persistence_Layer.Repositories
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		private readonly UserManager<User> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly string SecretKey;

		public UserRepository(ApplicationDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration) : base(context)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			SecretKey = configuration["JwtSettings:SecretKey"]!;
		}

		public async Task<BaseResponseModel> Login(LoginModel model)
		{
			bool isItTrue = await IsAnyItem(x => x.Email == model.Email);

			if (!isItTrue)
			{
				return new BaseResponseModel
				{
					Success = false,
					Message = "User does not exist with this email."
				};
			}

			User user = _userManager.FindByNameAsync(model.Email).GetAwaiter().GetResult();
			bool isValid = await _userManager.CheckPasswordAsync(user, model.Password);

			if (!isValid)
			{
				return new BaseResponseModel
				{
					Success = false,
					Message = "Invalid username or password!"
				};
			}

			var roles = await _userManager.GetRolesAsync(user);

			var token = HandleTokenValidator.HandleToken(roles, user, SecretKey);

			return new BaseResponseModel
			{
				Success = true,
				Message = "User logged in successfully.",
				Result = token
			};

		}

		public async Task<BaseResponseModel> Register(RegisterModel model)
		{
			if (await IsAnyItem(x => x.Email == model.Email))
			{
				return new BaseResponseModel
				{
					Success = false,
					Message = "User already exists with this email."
				};
			}

			var user = new User
			{
				UserName = model.Email,
				Email = model.Email,
				Name = model.Name
			};

			var result = await _userManager.CreateAsync(user, model.Password);

			if (!result.Succeeded)
			{
				return new BaseResponseModel
				{
					Success = false,
					Message = "User registration failed.",
					Exception = result.Errors.Select(e => e.Description).ToList()
				};
			}

			if (await _roleManager.RoleExistsAsync("Admin"))
			{
				await _userManager.AddToRoleAsync(user, "Customer");
			}
			else
			{
				var roles = new[] { "Admin", "Supervisor", "Customer" };

				foreach (var role in roles)
				{
					await _roleManager.CreateAsync(new IdentityRole(role));
				}

				await _userManager.AddToRolesAsync(user, roles);
			}

			return new BaseResponseModel
			{
				Success = true,
				Message = "User registered successfully."
			};
		}
	}
}
