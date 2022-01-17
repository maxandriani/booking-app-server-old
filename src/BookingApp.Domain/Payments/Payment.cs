using BookingApp.Bookings;
using BookingApp.Places;

namespace BookingApp.Payments;

/// <summary>
/// Any invoide record
/// </summary>
public class Payment
{
  public int Id { get; set; }
  /// <summary>
  /// What place is this money for/come
  /// </summary>
  public int PlaceId { get; set; }
  /// <summary>
  /// <inheritdoc cref="Payment.PlaceId" />
  /// </summary>
  public Place? Place { get; set; }
  /// <summary>
  /// What account this money deposits/withdraw
  /// </summary>
  public int AccountId { get; set; }
  /// <summary>
  /// <inheritdoc cref="Payment.Account" />
  /// </summary>
  public Account? Account { get; set; }
  /// <summary>
  /// Is there a related booking?
  /// </summary>
  public int? BookingId { get; set; }
  /// <summary>
  /// <inheritdoc cref="Payment.Booking" />
  /// </summary>
  public Booking? Booking { get; set; }
  /// <summary>
  /// When this balance occurs
  /// </summary>
  public DateOnly When { get; set; }
  /// <summary>
  /// Is this balance confirmed? 
  /// </summary>
  public DateOnly? ConfirmedAt { get; set; }
  /// <summary>
  /// How mucht is this record?
  /// </summary>
  public double Amount { get; set; }
}