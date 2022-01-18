namespace BookingApp.Bookings;

public class UpdateBookingDto
{
  /// <summary>
  /// <inheritdoc cref="Booking.PlaceId" />
  /// </summary>
  public int PlaceId { get; set; }
  /// <summary>
  /// <inheritdoc cref="Booking.Start" />
  /// </summary>
  public DateOnly Start { get; set; }
  /// <summary>
  /// <inheritdoc cref="Booking.Finish" />
  /// </summary>
  public DateOnly Finish { get; set; }
  /// <summary>
  /// <inheritdoc cref="Booking.ReservationCode" />
  /// </summary>
  public string ReservationCode { get; set; } = string.Empty;
  /// <summary>
  /// <inheritdoc cref="Booking.ReservedTo" />
  /// </summary>
  public string ReservedTo { get; set; } = string.Empty;
}