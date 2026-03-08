using Mapster;
using TodoApi.Application.DTOs;
using TodoApi.Domain.Entities;

namespace TodoApi.Application.Mappings;

public static class MappingConfig
{
  public static void RegisterMappings()
  {
    TypeAdapterConfig<TodoItem, TodoResponseDto>.NewConfig()
    .Map(dest => dest.Id, src => src.Id)
    .Map(dest => dest.Title, src => src.Title)
    .Map(dest => dest.Description, src => src.Description)
    .Map(dest => dest.IsCompleted, src => src.IsCompleted)
    .Map(dest => dest.Tag, src => src.Tag)
    .Map(dest => dest.CreatedAt, src => src.CreatedAt)
    .Map(dest => dest.UpdatedAt, src => src.UpdatedAt);
    
  }
}
