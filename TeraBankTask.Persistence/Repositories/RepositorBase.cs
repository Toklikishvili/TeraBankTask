using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TeraBankTask.Aplication.Interfaces;
using TeraBankTask.Persistence.DataContext;

namespace TeraBankTask.Persistence.Repositories;

public abstract class RepositorBase<Entity> : IRepositoryBase<Entity> where Entity : class 
{
    protected readonly TeraBankTaskDbContext _dbContext;
    private readonly DbSet<Entity> _dbSet;

    public RepositorBase(TeraBankTaskDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<Entity>();
    }

    public virtual async Task<IQueryable<Entity>> Set(Expression<Func<Entity , bool>> predicate) =>
        _dbContext.Set<Entity>().Where(predicate);

    public virtual async Task<IEnumerable<Entity>> GetAllAsync(Expression<Func<Entity , bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public virtual async Task<IEnumerable<Entity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<Entity> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id) ?? throw new KeyNotFoundException($"Record with key {id} not found");
    }

    public virtual async Task AddAsync(Entity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public virtual void Update(Entity entity)
    {
        _dbSet.Attach(entity);
        _dbContext.Entry(entity).State = EntityState.Modified;
    }

    public virtual async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
        }
    }
}
