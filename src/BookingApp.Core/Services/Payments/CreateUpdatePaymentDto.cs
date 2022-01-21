namespace BookingApp.Bookings;

public class CreateUpdatePaymentDto
{
  /// <summary>
  /// <inheritdoc cref="Payment.PlaceId" />
  /// </summary>
  /// <value></value>
  public int PlaceId { get; set; }
  /// <summary>
  /// <inheritdoc cref="Payment.AccountId" />
  /// </summary>
  public int AccountId { get; set; }
  /// <summary>
  /// <inheritdoc cref="Payment.Booking" />
  /// </summary>
  public int? BookingId { get; set; }
  /// <summary>
  /// <inheritdoc cref="Payment.When" />
  /// </summary>
  public DateOnly When { get; set; }
  /// <summary>
  /// <inheritdoc cref="Payment.ConfirmedAt" />
  /// </summary>
  public DateOnly? ConfirmedAt { get; set; }
  /// <summary>
  /// <inheritdoc cref="Payment.Amount" />
  /// </summary>
  public double Amount { get; set; }
}