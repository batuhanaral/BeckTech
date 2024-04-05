using BeckTech.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BeckTech.Data.Repositories.Abtractions
{
    public interface IRepository<T> where T : class, IEntityBase,new()
    {
        Task AddAsycn(T entity);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate , params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByGuidAsync(Guid id);
        Task<T> UpdateAsycn(T entity);
        Task DeleteAsycn(T entity);
        Task<bool> AnyAsycn(Expression<Func<T, bool>> predicate);
        Task<int> CountAsycn(Expression<Func<T, bool>> predicate=null);

        Task<int> SumAsync(Expression<Func<T, int>> selector, Expression<Func<T, bool>> predicate = null);


    }
}
