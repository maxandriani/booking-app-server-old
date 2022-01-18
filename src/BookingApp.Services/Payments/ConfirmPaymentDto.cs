namespace BookingApp.Payments;

public class ConfirmPaymentDto
{
  /// <summary>
  /// Date when this payment will confirm. Keep it blank for current date
  /// </summary>
  public DateOnly? ConfirmedAt { get; set; }
}