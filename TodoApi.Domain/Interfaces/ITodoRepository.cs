using TodoApi.Domain.Entities;

namespace TodoApi.Domain.Interfaces;


/// <summary>
/// Repository interface for TodoItem-specific operations.
/// </summary>
public interface ITodoRepository: IBaseRepository<TodoItem>
{
  /// <summary>Gets all todo items by completion status.</summary>
  /// <param name="isCompleted">Filter by completion status.</param>
  Task<IEnumerable<TodoItem>> GetByStatusAsync(bool isCompleted);

  /// <summary>Gets all todo items by tag name.</summary>
  /// <param name="tag">The tag name to filter by.</param>
  Task<IEnumerable<TodoItem>> GetByTagAsync(string tag);
}