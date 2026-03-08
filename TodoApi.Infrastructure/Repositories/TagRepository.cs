using MongoDB.Driver;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Interfaces;
using TodoApi.Infrastructure.Persistence;

namespace TodoApi.Infrastructure.Repositories;

public class TagRepository : BaseRepository<TodoTag>, ITagRepository
{
  public TagRepository(MongoDbContext context) : base(context.TodoTags){}

  public async Task<TodoTag?> GetByNameAsync(string name) => await _collection.Find(x => x.Name == name).FirstOrDefaultAsync();

  public async Task IncrementCountAsync(string name)
  {
    var filter = Builders<TodoTag>.Filter.Eq(x => x.Name, name);
    var update = Builders<TodoTag>.Update.Inc(x => x.TodoCount, 1).SetOnInsert(x => x.Name, name).SetOnInsert(x => x.CreatedAt, DateTime.UtcNow).Set(x=> x.UpdatedAt, DateTime.UtcNow);

    await _collection.UpdateOneAsync(filter, update, new UpdateOptions {IsUpsert= true});
  }

  public async Task DecrementCountAsync(string name)
  {
    var filter = Builders<TodoTag>.Filter.Eq(x => x.Name, name);
    var update = Builders<TodoTag>.Update.Inc(x => x.TodoCount, -1).Set(x => x.UpdatedAt, DateTime.UtcNow);

    await _collection.UpdateOneAsync(filter, update);
  } 
}
