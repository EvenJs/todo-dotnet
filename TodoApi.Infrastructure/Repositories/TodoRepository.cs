using MongoDB.Driver;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Interfaces;
using TodoApi.Infrastructure.Persistence;

namespace TodoApi.Infrastructure.Repositories;

public class TodoRepository : BaseRepository<TodoItem>, ITodoRepository
{
  public TodoRepository(MongoDbContext context) : base(context.TodoItems)
  {
    
  }

  public async Task<IEnumerable<TodoItem>> GetByStatusAsync(bool isCompleted) => await _collection.Find(x => x.IsCompleted == isCompleted).ToListAsync();

  public async Task<IEnumerable<TodoItem>> GetByTagAsync(string tag) => await _collection.Find(x => x.Tag == tag).ToListAsync();
}
