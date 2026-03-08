
namespace TodoApi.Application.DTOs;

public class CreateTodoDto
{
  public string Title { get; set; } = string.Empty;
  public string? Description { get; set; }
  public string Tag { get; set; } = string.Empty;
}