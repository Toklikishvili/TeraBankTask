namespace TeraBankTask.Aplication.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    ITransactionRepository TransactionRepository { get; }
    Task<int> CompleteAsync();
}
