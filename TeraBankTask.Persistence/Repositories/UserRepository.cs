using Microsoft.EntityFrameworkCore;
using System.Net;
using TeraBankTask.Aplication.Interfaces;
using TeraBankTask.Domain.Entities;
using TeraBankTask.Persistence.DataContext;

namespace TeraBankTask.Persistence.Repositories;

public class UserRepository : RepositorBase<User>, IUserRepository
{
    public UserRepository(TeraBankTaskDbContext dbContext) : base(dbContext)
    {
    }

    public override Task AddAsync(User entity)
    {
        entity.Password = HashPassword(entity.Password);
        return base.AddAsync(entity);
    }

    private string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}
