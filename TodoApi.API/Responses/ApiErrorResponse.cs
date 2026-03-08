
namespace Todo.API.Response;

public class ApiErrorResponse
{
  public bool Success { get; set; } = false;
  public int StatusCode { get; set; }
  public string Message { get; set; } = string.Empty;
  public IEnumerable<string>? Errors { get; set; }

  public static ApiErrorResponse From(int statusCode, string message, IEnumerable<string>? errors = null) => new()
  {
    StatusCode = statusCode,
    Message = message,
    Errors = errors
  };

}