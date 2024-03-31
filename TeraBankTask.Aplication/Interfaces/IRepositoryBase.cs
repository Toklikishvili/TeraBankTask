using System.Linq.Expressions;

namespace TeraBankTask.Aplication.Interfaces;

public interface IRepositoryBase<Entity> where Entity : class
{
    Task<IQueryable<Entity>> Set(Expression<Func<Entity , bool>> predicate);
    Task<Entity> GetByIdAsync(int id);
    Task AddAsync(Entity entity);
    void Update(Entity entity);
}
