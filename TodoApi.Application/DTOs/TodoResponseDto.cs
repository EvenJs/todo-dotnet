
namespace TodoApi.Application.DTOs;

public class TodoResponseDto
{
  public string Id { get; set; } = string.Empty;
  public string Title { get; set; } = string.Empty;
  public string? Description { get; set; }
  public bool isCompleted { get; set; } 
  public string Tag { get; set; } = string.Empty;

  public DateTime CreateAt { get; set; }
  public DateTime updateAt { get; set; }
}