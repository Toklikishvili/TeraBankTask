using System.Linq.Expressions;

namespace TeraBankTask.Aplication.Interfaces;

public interface IRepositoryBase<Entity> where Entity : class
{
    Task<IQueryable<Entity>> Set(Expression<Func<Entity , bool>> predicate);
    Task<IEnumerable<Entity>> GetAllAsync(Expression<Func<Entity , bool>> predicate);
    Task<IEnumerable<Entity>> GetAllAsync();
    Task<Entity> GetByIdAsync(int id);
    Task AddAsync(Entity entity);
    void Update(Entity entity);
    Task DeleteAsync(int id);

}
