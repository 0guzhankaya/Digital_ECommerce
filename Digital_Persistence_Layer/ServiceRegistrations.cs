using Digital_Infrastructure_Layer;
using Digital_Persistence_Layer.MappingProfiles;
using Digital_Persistence_Layer.Models;
using Digital_Persistence_Layer.Repositories;
using Digital_Persistence_Layer.Repositories.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Digital_Persistence_Layer
{
	public static class ServiceRegistrations
	{
		public static void AddPersistenceServiceRegistration(this IServiceCollection services, IConfiguration configuration = null)
		{
			services.AddScoped(typeof(BaseResponseModel));
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IMainCategoryRepository, MainCategoryRepository>();
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			services.AddInfrastructureLayerServices(configuration);
			services.AddAutoMapper(typeof(MapperProfile));
		}
	}
}
