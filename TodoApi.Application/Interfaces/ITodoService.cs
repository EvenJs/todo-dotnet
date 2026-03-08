using TodoApi.Application.DTOs;

namespace TodoApi.Application.Interfaces;

/// <summary>
/// Service interface for managing Todo items.
/// </summary>
public interface ITodoService
{
  /// <summary>Gets all todo items.</summary>
  Task<IEnumerable<TodoResponseDto>> GetAllAsync();

  /// <summary>Gets a single todo item by ID.</summary>
  /// <param name="id">The todo item ID.</param>
  Task<TodoResponseDto> GetByIdAsync(string id);

  /// <summary>Creates a new todo item and updates the associated tag count.</summary>
  /// <param name="dto">The create todo request data.</param>
  Task<TodoResponseDto> CreateAsync(CreateTodoDto dto);

  /// <summary>Updates an existing todo item.</summary>
  /// <param name="id">The todo item ID.</param>
  /// <param name="dto">The update todo request data.</param>
  Task<TodoResponseDto> UpdateAsync(string id, UpdateTodoDto dto);

  /// <summary>Deletes a todo item and decrements the associated tag count.</summary>
  /// <param name="id">The todo item ID.</param>
  Task DeleteAsync(string id);
}