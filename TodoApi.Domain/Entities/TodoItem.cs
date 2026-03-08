
namespace TodoApi.Domain.Entities
{
  public class TodoItem : BaseEntity
  {
    public string Title {get; set;} = string.Empty;
    public string? Description {get; set;}
    public bool IsCompleted {get; set;} = false;
    public string Tag {get; set;} = string.Empty;
  }

}