
namespace TodoApi.Domain.Interfaces;

/// <summary>
/// Generic base repository interface for common CRUD operations.
/// </summary>
/// <typeparam name="T">The entity type, must inherit from BaseEntity.</typeparam>
public interface IBaseRepository<T>
{
  /// <summary>Gets all entities.</summary>
  Task<IEnumerable<T>> GetAllAsync();


  /// <summary>Gets a single entity by its ID.</summary>
  /// <param name="id">The entity ID.</param>
  Task<T?> GetByIdAsync(string id);

  /// <summary>Inserts a new entity.</summary>
  /// <param name="entity">The entity to insert.</param>
  Task CreateAsync(T entity);
  
  /// <summary>Replaces an existing entity.</summary>
  /// <param name="id">The entity ID.</param>
  /// <param name="entity">The updated entity.</param>
  Task UpdateAsync(string id, T entity);

  /// <summary>Deletes an entity by its ID.</summary>
  /// <param name="id">The entity ID.</param>
  Task DeleteAsync(string id);
}