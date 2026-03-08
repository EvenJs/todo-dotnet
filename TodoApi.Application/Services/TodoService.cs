using Mapster;
using TodoApi.Application.DTOs;
using TodoApi.Application.Interfaces;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Exceptions;
using TodoApi.Domain.Interfaces;

namespace TodoApi.Application.Services;

public class TodoService : ITodoService
{
  private readonly ITodoRepository _todoRepository;
  private readonly ITagRepository _tagRepository;
  private readonly IUnitOfWork _unitOfWork;

  public TodoService(
    ITodoRepository todoRepository,
    ITagRepository tagRepository,
    IUnitOfWork unitOfWork)
  {
    _todoRepository = todoRepository;
    _tagRepository = tagRepository;
    _unitOfWork = unitOfWork;
  }

  public async Task<IEnumerable<TodoResponseDto>> GetAllAsync()
  {
    var todos = await _todoRepository.GetAllAsync();
    return todos.Adapt<IEnumerable<TodoResponseDto>>();
  }

  public async Task<TodoResponseDto> GetByIdAsync(string id)
  {
    var todo = await _todoRepository.GetByIdAsync(id) ?? throw AppException.NotFound($"Todo with ID '{id}' was not found.");

    return todo.Adapt<TodoResponseDto>();
  }

  public async Task<TodoResponseDto> CreateAsync(CreateTodoDto dto)
  {
    var todo = new TodoItem
    {
      Title = dto.Title,
      Description = dto.Description,
      Tag = dto.Tag,
      IsCompleted = false
    };

    await _unitOfWork.BeginTransactionAsync();
    try
    {
      await _todoRepository.CreateAsync(todo);
      await _tagRepository.IncrementCountAsync(todo.Tag);
      await _unitOfWork.CommitAsync();
    }
    catch
    {
      await _unitOfWork.RollbackAsync();
      throw;
    }

    return todo.Adapt<TodoResponseDto>();
  }

  public async Task<TodoResponseDto> UpdateAsync(string id, UpdateTodoDto dto)
  {
    var todo = await _todoRepository.GetByIdAsync(id) ?? throw AppException.NotFound($"Todo with ID '{id}' was not found.");

    todo.Title = dto.Title;
    todo.Description = dto.Description;
    todo.Tag = dto.Tag;
    todo.IsCompleted = dto.IsCompleted;

    await _todoRepository.UpdateAsync(id, todo);
    
    return todo.Adapt<TodoResponseDto>();
  }

  public async Task DeleteAsync(string id)
  {
    var todo = await _todoRepository.GetByIdAsync(id) ?? throw AppException.NotFound($"Todo with ID '{id}' was not found.");

    await _unitOfWork.BeginTransactionAsync();
    try
    {
      await _todoRepository.DeleteAsync(id);
      await _tagRepository.DecrementCountAsync(todo.Tag);
      await _unitOfWork.CommitAsync();
    }
    catch
    {
      await _unitOfWork.RollbackAsync();
      throw;
    }
  }
}