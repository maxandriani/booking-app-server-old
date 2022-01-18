namespace BookingApp.Common.Requests;

public interface ISearchableRequest
{
  string? Search { get; set; }
}