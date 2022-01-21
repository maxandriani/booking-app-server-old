namespace BookingApp.Services.Requests;

public interface ISearchableRequest
{
  string? Search { get; set; }
}