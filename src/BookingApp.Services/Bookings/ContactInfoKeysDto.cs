namespace BookingApp.Bookings;

public class ContactInfoKeysDto
{
  public int Id { get; set; }
  /// <summary>
  /// <inheritdoc cref="ContactInfo.BookingId" />
  /// </summary>
  public int BookingId { get; set; }
}