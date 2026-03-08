
namespace TodoApi.Application.DTOs;

public class TodoResponseDto
{
  public string Id { get; set; } = string.Empty;
  public string Title { get; set; } = string.Empty;
  public string? Description { get; set; }
  public bool IsCompleted { get; set; } 
  public string Tag { get; set; } = string.Empty;

  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}