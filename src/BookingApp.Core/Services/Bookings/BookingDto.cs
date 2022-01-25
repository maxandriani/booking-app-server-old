using BookingApp.Places;

namespace BookingApp.Bookings;

public class BookingDto
{
  public int Id { get; set; }
  /// <summary>
  /// <inheritdoc cref="Booking.Id" />
  /// </summary>
  public int PlaceId { get; set; }
  /// <summary>
  /// <inheritdoc cref="Booking.PlaceId"/>
  /// </summary>
  public PlaceDto? Place { get; set; }
  /// <summary>
  /// <inheritdoc cref="Booking.PlaceId">
  /// </summary>
  public DateTime Start { get; set; }
  /// <summary>
  /// <inheritdoc cref="Booking.Start" />
  /// </summary>
  public DateTime Finish { get; set; }
  /// <summary>
  /// <inheritdoc cref="Booking.Finish" />
  /// </summary>
  public string ReservationCode { get; set; } = string.Empty;
  /// <summary>
  /// <inheritdoc cref="Booking.ReserverdTo" />
  /// </summary>
  public string ReservedTo { get; set; } = string.Empty;
}