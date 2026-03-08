using System.Security.Cryptography.X509Certificates;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using TodoApi.Domain.Entities;
using TodoApi.Infrastructure.Settings;

namespace TodoApi.Infrastructure.Persistence;

public class MongoDbContext
{
  private readonly IMongoDatabase _database;
  private readonly MongoClient _client;

  public MongoDbContext(MongodbSettings settings)
  {
    RegisterClassMaps();
    _client = new MongoClient(settings.ConnectionString);
    _database = _client.GetDatabase(settings.DatabaseName);
    TodoItems = _database.GetCollection<TodoItem>(settings.TodoItemsCollectionName);
    TodoTags = _database.GetCollection<TodoTag>(settings.TodoTagsCollectionName);

  }

  public IMongoCollection<TodoItem> TodoItems { get; }
  public IMongoCollection<TodoTag> TodoTags { get; }

  public IClientSessionHandle StartSession() => _client.StartSession();

  private static void RegisterClassMaps()
  {
    if (!BsonClassMap.IsClassMapRegistered(typeof(BaseEntity)))
    {
      BsonClassMap.RegisterClassMap<BaseEntity>(cm =>
      {
        cm.AutoMap();
        cm.MapIdMember(c => c.Id).SetSerializer(new StringSerializer(BsonType.ObjectId));
        cm.MapMember(c => c.CreatedAt).SetElementName("createdAt");
        cm.MapMember(c => c.UpdatedAt).SetElementName("updatedAt");
      });
    }

  }

}

