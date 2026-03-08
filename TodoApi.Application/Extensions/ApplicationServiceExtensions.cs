using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TodoApi.Application.Interfaces;
using TodoApi.Application.Services;

namespace TodoApi.Application.Extensions;

public static class ApplicationServiceExtensions
{
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddScoped<ITodoService, TodoService>();
    services.AddValidatorsFromAssemblyContaining<TodoService>();

    return services;
  }
}