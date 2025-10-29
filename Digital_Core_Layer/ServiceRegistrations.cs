using Digital_Core_Layer.Services.Abstract;
using Digital_Core_Layer.Services.Concrete;
using Digital_Domain_Layer.Entities;
using Digital_Persistence_Layer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Digital_Core_Layer
{
	public static class ServiceRegistrations
	{
		public static void AddCoreRegisterServices(this IServiceCollection services, IConfiguration configuration = null)
		{
			services.AddPersistenceServiceRegistration(configuration);
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IMainCategoryService, MainCategoryService>();
			services.AddScoped<ISubCategoryService, SubCategoryService>();
			services.AddDbContext<Digital_Persistence_Layer.AppDbContext.ApplicationDbContext>(options =>
			{
				options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
			});
			services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<Digital_Persistence_Layer.AppDbContext.ApplicationDbContext>();
		}
	}
}
