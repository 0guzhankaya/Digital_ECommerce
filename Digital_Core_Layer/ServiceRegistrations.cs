using Digital_Domain_Layer.Entities;
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
			services.AddDbContext<Digital_Persistence_Layer.AppDbContext.ApplicationDbContext>(options =>
			{
				options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
			});
			services.AddIdentityCore<User>().AddEntityFrameworkStores<Digital_Persistence_Layer.AppDbContext.ApplicationDbContext>();
		}
	}
}
