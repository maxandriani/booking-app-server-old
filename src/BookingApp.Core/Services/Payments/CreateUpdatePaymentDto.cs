namespace BookingApp.Payments;

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
  public DateTime When { get; set; }
  /// <summary>
  /// <inheritdoc cref="Payment.Amount" />
  /// </summary>
  public double Amount { get; set; }
  /// <summary>
  /// <inheritdoc cref="Payment.Description" />
  /// </summary>
  /// <value></value>
  public string Description { get; set; } = string.Empty;
}