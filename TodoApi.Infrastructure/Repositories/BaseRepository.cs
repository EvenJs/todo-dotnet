using MongoDB.Driver;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Interfaces;
using TodoApi.Infrastructure.Persistence;

namespace TodoApi.Infrastructure.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T: BaseEntity
{
  protected readonly IMongoCollection<T> _collection;

  protected BaseRepository(IMongoCollection<T> collection)
  {
    _collection = collection;
  }

  public async Task<IEnumerable<T>> GetAllAsync() => await _collection.Find(_=>true).ToListAsync();

  public async Task<T?> GetByIdAsync(String id) => await _collection.Find(x=>x.Id==id).FirstOrDefaultAsync();

  public async Task CreateAsync(T entity) => await _collection.InsertOneAsync(entity);

  public async Task UpdateAsync(string id, T entity)
  {
    entity.UpdatedAt = DateTime.UtcNow;
    await _collection.ReplaceOneAsync(x => x.Id ==id, entity);
  }

  public async Task DeleteAsync(string id) => await _collection.DeleteOneAsync(x => x.Id ==id);

}