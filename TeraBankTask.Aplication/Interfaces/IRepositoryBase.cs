﻿using System.Linq.Expressions;

namespace TeraBankTask.Aplication.Interfaces;

public interface IRepositoryBase<Entity> where Entity : class
{
    Task<IEnumerable<Entity>> GetAllAsync(Expression<Func<Entity , bool>> predicate);
    Task<IEnumerable<Entity>> GetAllAsync();
    Task<Entity> GetByIdAsync(int id);
    Task AddAsync(Entity entity);
    Task DeleteAsync(int id);
}
