
namespace TodoApi.Domain.Entities
{
  public abstract class BaseEntity
  {
    public string Id { get; set; } = GenerateNewId();
    public DateTime CreatedAt {get; set;} = DateTime.UtcNow;
    public DateTime UpdatedAt {get; set;} = DateTime.UtcNow;

     private static string GenerateNewId()
    {
      var timestamp = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
      var random = new byte[8];
      System.Security.Cryptography.RandomNumberGenerator.Fill(random);
      return string.Concat(
        timestamp.ToString("x8"),
        Convert.ToHexString(random).ToLower()
      );
    }
  }
}