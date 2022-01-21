namespace BookingApp.Services.Results;

public class ErrorResult
{
  public List<ErrorMessage> Errors { get; set; } = new();
}

public class ErrorMessage
{
  public string Message { get; set; } = string.Empty;
  public string? Field { get; set; }
}