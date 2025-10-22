using Digital_Persistence_Layer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Digital_Core_Layer.Services
{
	public static class ServiceRegistrations
	{
		public static void AddPersistenceServiceRegistration(this IServiceCollection services, IConfiguration configuration = null)
		{
			services.AddScoped(typeof(BaseResponseModel));
		}
	}
}
