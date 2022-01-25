namespace BookingApp.Bookings;

public class SearchContactInfoRequest {
  public string? Search { get; set; } = string.Empty;
  public int BookingId { get; set; }
}