using MongoDB.Driver;
using TodoApi.Domain.Interfaces;

namespace TodoApi.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
  private readonly MongoDbContext _context;
  private IClientSessionHandle? _session;

  public UnitOfWork(MongoDbContext context)
  {
    _context = context;
  }

  public async Task BeginTransactionAsync()
  {
    _session = _context.StartSession();
    await Task.Run(() => _session.StartTransaction());
  }

  public async Task CommitAsync()
  {
    if (_session is null)
      throw new InvalidOperationException("Transaction has not been started.");

    await _session.CommitTransactionAsync();

  }

  public async Task RollbackAsync()
  {
    if (_session is null)
      throw new InvalidOperationException("Transaction has not been started.");

    await _session.AbortTransactionAsync();
  }

  public void Dispose()
  {
    _session?.Dispose();
  }
}