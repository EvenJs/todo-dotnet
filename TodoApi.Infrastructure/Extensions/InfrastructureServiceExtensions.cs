using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoApi.Domain.Interfaces;
using TodoApi.Infrastructure.Persistence;
using TodoApi.Infrastructure.Repositories;
using TodoApi.Infrastructure.Settings;

namespace TodoApi.Infrastructure.Extensions;

public static class InfraStructureServiceExtensions
{
  public static IServiceCollection AddInfrastructure(
    this IServiceCollection services,
    IConfiguration configuration
  )
  {
    var settings = configuration.GetSection("MongoDbSettings").Get<MongodbSettings>()!;
    services.AddSingleton(settings);

    services.AddSingleton<MongoDbContext>();

    services.AddScoped<ITodoRepository, TodoRepository>();
    services.AddScoped<ITagRepository, TagRepository>();

    services.AddScoped<IUnitOfWork, UnitOfWork>();

     return services;
  }
  


 
}
