using System.Linq.Expressions;
using CarsShop.Domain;

namespace CarsShop.Dal.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> ListAllAsync();
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T> GetByIdWithInclude<T>(int id, params Expression<Func<T, object>>[] includeProperties) where T : BaseEntity;
    Task<T> GetEntityWithSpec(ISpecification<T> spec);
    Task<IEnumerable<T>> ListAsync(ISpecification<T> spec);
    Task<int> CountAsync(ISpecification<T> spec);
    Task SaveChangesAsync();
}