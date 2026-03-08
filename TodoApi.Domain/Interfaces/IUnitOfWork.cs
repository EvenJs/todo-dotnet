
namespace TodoApi.Domain.Interfaces;

/// <summary>
/// Unit of Work interface for managing MongoDB transactions.
/// </summary>
public interface IUnitOfWork : IDisposable
{
  /// <summary>Begins a new transaction.</summary>
  Task BeginTransactionAsync();

  /// <summary>Commits the current transaction.</summary>
  Task CommitAsync();

  /// <summary>Rolls back the current transaction.</summary>
  Task RollbackAsync();
}