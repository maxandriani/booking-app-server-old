namespace BookingApp.Bookings;

public class CreateUpdateBookingDto
{
  /// <summary>
  /// <inheritdoc cref="Booking.PlaceId" />
  /// </summary>
  public int PlaceId { get; set; }
  /// <summary>
  /// <inheritdoc cref="Booking.Start" />
  /// </summary>
  public DateTime Start { get; set; }
  /// <summary>
  /// <inheritdoc cref="Booking.Finish" />
  /// </summary>
  public DateTime Finish { get; set; }
  /// <summary>
  /// <inheritdoc cref="Booking.ReservationCode" />
  /// </summary>
  public string ReservationCode { get; set; } = string.Empty;
  /// <summary>
  /// <inheritdoc cref="Booking.ReservedTo" />
  /// </summary>
  public string ReservedTo { get; set; } = string.Empty;
}