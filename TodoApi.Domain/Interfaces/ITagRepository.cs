using TodoApi.Domain.Entities;

namespace TodoApi.Domain.Interfaces;

/// <summary>
/// Repository interface for TodoTag-specific operations.
/// </summary>
public interface ITagRepository: IBaseRepository<TodoTag>
{
  /// <summary>Gets a tag by its name.</summary>
  /// <param name="name">The tag name.</param>
  Task<TodoTag?> GetByNameAsync(string name);

  /// <summary>Increments the TodoCount of a tag by 1. Creates the tag if it does not exist.</summary>
  /// <param name="name">The tag name.</param>
  Task IncrementCountAsync(string name);

  /// <summary>Decrements the TodoCount of a tag by 1.</summary>
  /// <param name="name">The tag name.</param>
  Task DecrementCountAsync(string name);

}