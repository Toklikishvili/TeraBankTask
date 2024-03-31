using TeraBankTask.Aplication.Interfaces;
using TeraBankTask.Domain.Entities;
using TeraBankTask.Persistence.DataContext;

namespace TeraBankTask.Persistence.Repositories;

public class TransactionRepository : RepositorBase<Transaction>, ITransactionRepository
{
    public TransactionRepository(TeraBankTaskDbContext dbContext) : base(dbContext)
    {
    }
}
