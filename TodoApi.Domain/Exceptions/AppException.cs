
namespace TodoApi.Domain.Exceptions;

public class AppException : Exception
{
  public int StatusCode { get; }

  public AppException(int statusCode, string message) : base(message)
  {
    StatusCode = statusCode;
  }

  public static AppException NotFound(string message) => new (404, message);
  public static AppException BadRequest(string message) => new (400, message);
  public static AppException InternalServerError(string message) => new (500, message);
}