using System.Linq.Expressions;
using CarsShop.Dal.Interfaces;
using CarsShop.Dal.Specification;
using CarsShop.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarsShop.Dal.Repository;

public class EfRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly CarShopDbContext _context;

    public EfRepository(CarShopDbContext context)
    {
        _context = context;
    }

    public async Task<T> GetByIdAsync(int id)
        => await _context
            .Set<T>()
            .FindAsync(id);

    public async Task<IEnumerable<T>> ListAllAsync()
        => await _context
            .Set<T>()
            .ToListAsync();

    public async Task AddAsync(T entity) 
        => await _context
            .Set<T>()
            .AddAsync(entity);

    public void Update(T entity)
    {
        _context.Set<T>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(T entity) 
        => _context
            .Set<T>()
            .Remove(entity);

    public async Task<T> GetByIdWithInclude<T>(int id, params Expression<Func<T, object>>[] includeProperties) where T : BaseEntity
    {
        var query = IncludeProperties(includeProperties);
        return await query
            .FirstOrDefaultAsync(entity => entity.Id == id);
    }
    
    public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<T>> ListAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).ToListAsync();
    }

    public async Task<int> CountAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).CountAsync();
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
    }


    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
    
    private IQueryable<T> IncludeProperties<T>(params Expression<Func<T, object>>[] includeProperties) where T : BaseEntity
    {
        IQueryable<T> entities = _context.Set<T>();
        foreach (var includeProperty in includeProperties)
        {
            entities = entities.Include(includeProperty);
        }
        return entities;
    }
    
}