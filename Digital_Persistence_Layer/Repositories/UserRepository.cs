using Digital_Domain_Layer.Entities;
using Digital_Persistence_Layer.AppDbContext;
using Digital_Persistence_Layer.Repositories.Interface;

namespace Digital_Persistence_Layer.Repositories
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		public UserRepository(ApplicationDbContext context) : base(context)
		{
		}

		public Task Login()
		{
			throw new NotImplementedException();
		}

		public Task Register()
		{
			throw new NotImplementedException();
		}
	}
}
