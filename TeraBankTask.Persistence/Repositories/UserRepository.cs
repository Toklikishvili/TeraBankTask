using TeraBankTask.Aplication.Interfaces;
using TeraBankTask.Domain.Entities;
using TeraBankTask.Persistence.DataContext;

namespace TeraBankTask.Persistence.Repositories;

public class UserRepository : RepositorBase<User>, IUserRepository
{
    public UserRepository(TeraBankTaskDbContext dbContext) : base(dbContext)
    {
    }
}
