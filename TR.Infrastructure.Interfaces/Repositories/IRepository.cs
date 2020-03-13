using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TR.Infrastructure.Interfaces.Inclusions;
using TR.Infrastructure.Interfaces.Infrastructure;

namespace TR.DAL.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        Expression<Func<T, IComparable>> DefaultOrderBy(); 

        Task<IEnumerable<TViewModel>> QueryAsync<TViewModel>(
            Expression<Func<T, bool>> filterClause,
            IInclusionStrategy<T> inclusionStrategy = null);        

        Task<IPagedList<TViewModel>> QueryAsync<TViewModel>(
            Expression<Func<T, bool>> filterClause,
            int page,
            int pageSize,
            Expression<Func<T, IComparable>> orderBy,
            bool descending = false,
            IInclusionStrategy<T> inclusionStrategy = null);


        //Task<TViewModel> GetByIdAsync<TViewModel>(int id);

        T AddOrUpdate(T entity);
        Task<T> AddOrUpdateAsync(T entity);

        Task<T> AddOrUpdateFromViewModelAsync<TViewModel>(TViewModel model);
        T AddOrUpdateFromViewModel<TViewModel>(TViewModel model);

        T Delete(T entity);
        Task<T> DeleteAsync(T entity);

        Task<bool> AddRangeAsync(ICollection<T> entity);
    }
}
