using Microsoft.AspNetCore.Mvc;
using Todo.API.Response;
using TodoApi.API.Response;
using TodoApi.Application.DTOs;
using TodoApi.Application.Interfaces;

namespace TodoApi.API.Controllers;

/// <summary>
/// Controller for managing Todo items.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
  private readonly ITodoService _todoService;
  
  public TodoController(ITodoService todoService)
  {
    _todoService = todoService;
  }

  /// <summary>Gets all todo items.</summary>
  /// <returns>A list of all todo items.</returns>
  /// <response code="200">Returns the list of todo items.</response>
  [HttpGet]
  [ProducesResponseType(typeof(ApiResponse<IEnumerable<TodoResponseDto>>), StatusCodes.Status200OK)]
  public async Task<IActionResult> GetAll()
  {
    var todos = await _todoService.GetAllAsync();
    return Ok(ApiResponse<IEnumerable<TodoResponseDto>>.Ok(todos));
  }


  /// <summary>Gets a single todo item by ID.</summary>
  /// <param name="id">The todo item ID.</param>
  /// <returns>The todo item.</returns>
  /// <response code="200">Returns the todo item.</response>
  /// <response code="404">Todo item not found.</response>
  [HttpGet("{id}")]
  [ProducesResponseType(typeof(ApiResponse<TodoResponseDto>), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
  public async Task<IActionResult> GetById(string id)
  {
    var todo = await _todoService.GetByIdAsync(id);
    return Ok(ApiResponse<TodoResponseDto>.Ok(todo));
  }

  /// <summary>Creates a new todo item.</summary>
  /// <param name="dto">The create todo request.</param>
  /// <returns>The created todo item.</returns>
  /// <response code="201">Todo item created successfully.</response>
  /// <response code="400">Validation failed.</response>
  [HttpPost]
  [ProducesResponseType(typeof(ApiResponse<TodoResponseDto>), StatusCodes.Status201Created)]
  [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
  public async Task<IActionResult> Create([FromBody] CreateTodoDto dto)
  {
    var todo = await _todoService.CreateAsync(dto);
    return CreatedAtAction(nameof(GetById), new { id = todo.Id }, ApiResponse<TodoResponseDto>.Ok(todo));
  }

  /// <summary>Updates an existing todo item.</summary>
  /// <param name="id">The todo item ID.</param>
  /// <param name="dto">The update todo request.</param>
  /// <returns>The updated todo item.</returns>
  /// <response code="200">Todo item updated successfully.</response>
  /// <response code="400">Validation failed.</response>
  /// <response code="404">Todo item not found.</response>
  [HttpPut("{id}")]
  [ProducesResponseType(typeof(ApiResponse<TodoResponseDto>), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
  public async Task<IActionResult> Update(string id, [FromBody] UpdateTodoDto dto)
  {
    var todo = await _todoService.UpdateAsync(id, dto);
    return Ok(ApiResponse<TodoResponseDto>.Ok(todo));
  }

  /// <summary>Deletes a todo item.</summary>
  /// <param name="id">The todo item ID.</param>
  /// <response code="204">Todo item deleted successfully.</response>
  /// <response code="404">Todo item not found.</response>
  [HttpDelete("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
  public async Task<IActionResult> Delete(string id)
  {
    await _todoService.DeleteAsync(id);
    return NoContent();
  }
}