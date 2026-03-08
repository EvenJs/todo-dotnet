using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TodoApi.Application.Interfaces;
using TodoApi.Application.Mappings;
using TodoApi.Application.Services;

namespace TodoApi.Application.Extensions;

public static class ApplicationServiceExtensions
{
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    MappingConfig.RegisterMappings();
    services.AddScoped<ITodoService, TodoService>();
    services.AddValidatorsFromAssemblyContaining<TodoService>();

    return services;
  }
}