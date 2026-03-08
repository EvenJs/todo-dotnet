using System.Net;
using System.Text.Json;
using FluentValidation;
using Todo.API.Response;
using TodoApi.API.Response;
using TodoApi.Domain.Exceptions;

namespace TodoApi.API.Middleware;

public class ExceptionMiddleware
{
  private readonly RequestDelegate _next;
  private readonly ILogger<ExceptionMiddleware> _logger;

  public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
  {
    _next = next;
    _logger = logger;
  }

  public async Task InvokeAsync(HttpContext context)
  {
    try
    {
      await _next(context);
    }
    catch (ValidationException ex)
    {
      _logger.LogWarning("Validation failed: {Errors}", ex.Message);
      await HandleExceptionAsync(
        context,
        HttpStatusCode.BadRequest,
        "Validation failed",
        ex.Errors.Select(e => e.ErrorMessage)
      );
    }
    catch (AppException ex)
    {
      _logger.LogWarning("Application exception: {Message}", ex.Message);
      await HandleExceptionAsync(context,(HttpStatusCode)ex.StatusCode,ex.Message);
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Unhandled exception occurred");
      await HandleExceptionAsync(
        context,
        HttpStatusCode.InternalServerError,
        "An unexpected error occurred"
      );
    }
  }

  private static async Task HandleExceptionAsync(
    HttpContext context,
    HttpStatusCode statusCode,
    string message,
    IEnumerable<string>? errors = null)
  {
    context.Response.ContentType = "application/json";
    context.Response.StatusCode = (int)statusCode;

    var response = ApiErrorResponse.From((int)statusCode, message, errors);
    var json = JsonSerializer.Serialize(response, new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase});

    await context.Response.WriteAsync(json);
  }
}