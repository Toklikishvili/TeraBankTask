using TeraBankTask.Aplication.Interfaces;
using TeraBankTask.Persistence.DataContext;

namespace TeraBankTask.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly TeraBankTaskDbContext _context;

    private readonly Lazy<IUserRepository> _userRepository;
    private readonly Lazy<ITransactionRepository> _transactionRepository;
    private bool disposed;

    public UnitOfWork(TeraBankTaskDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_context));
        _transactionRepository = new Lazy<ITransactionRepository>(() => new TransactionRepository(_context));
    }

    public IUserRepository UserRepository => _userRepository.Value;
    public ITransactionRepository TransactionRepository => _transactionRepository.Value;

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        disposed = true;
    }
}
