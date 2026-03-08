
namespace TodoApi.Domain.Entities
{
  public class TodoTag : BaseEntity
  {
    public string Name {get; set;} = string.Empty;
    public int TodoCount {get; set;} = 0;
  } 

}