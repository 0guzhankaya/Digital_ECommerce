using Digital_Domain_Layer.Extensions;
using System.Linq.Expressions;

namespace Digital_Persistence_Layer.Repositories.Interface
{
	public interface IRepository<T> where T : new()
	{
		Task<T> GetById(Guid id);
		Task<bool> IsAnyItem(Expression<Func<T, bool>> filter);
		Task<IEnumerable<T>> GetAll();
		Task<T> Add(T entity);
		Task<List<T>> AddRange(List<T> entities);
		Task<T> GetWhere(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties);
		Task<T> Update(Guid id, T entity);
		Task Delete(Guid id);
		Task<PageResult<T>> GetPagedResult(Expression<Func<T, bool>>? filter = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			int pageNumber = 1, int pageSize = 10);

		Task<IEnumerable<T>> GetWithIncludeProperties(params Expression<Func<T, object>>[] includeProperties);
	}
}
