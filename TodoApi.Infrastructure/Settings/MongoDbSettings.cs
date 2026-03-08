
namespace TodoApi.Infrastructure.Settings;

public class MongodbSettings
{
  public string ConnectionString {get; set;} = string.Empty;
  public string DatabaseName {get; set;} = string.Empty;
  public string TodoItemsCollectionName {get; set;} = string.Empty;
  public string TodoTagsCollectionName {get; set;} = string.Empty;
}
