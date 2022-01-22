using BookingApp.Bookings;
using BookingApp.Places;

namespace BookingApp.Payments;

public class PaymentDto
{
  public int Id { get; set; }
  /// <summary>
  /// <inheritdoc cref="Payment.PlaceId" />
  /// </summary>
  public int PlaceId { get; set; }
  /// <summary>
  /// <inheritdoc cref="Payment.PlaceId" />
  /// </summary>
  public PlaceDto? Place { get; set; }
  /// <summary>
  /// <inheritdoc cref="Payment.AccountId" />
  /// </summary>
  public int AccountId { get; set; }
  /// <summary>
  /// <inheritdoc cref="Payment.AccountId" />
  /// </summary>
  public AccountDto? Account { get; set; }
  /// <summary>
  /// <inheritdoc cref="Payment.BookingId" />
  /// </summary>
  public int? BookingId { get; set; }
  /// <summary>
  /// <inheritdoc cref="Payment.BookingId" />
  /// </summary>
  public BookingDto? Booking { get; set; }
  /// <summary>
  /// <inheritdoc cref="Payment.BookingId" />
  /// </summary>
  public DateTime When { get; set; }
  /// <summary>
  /// <inheritdoc cref="Payment.ConfirmedAt" />
  /// </summary>
  public DateTime? ConfirmedAt { get; set; }
  /// <summary>
  /// <inheritdoc cref="Payment.Amount" />
  /// </summary>
  public double Amount { get; set; }
  /// <summary>
  /// <inheritdoc cref="Payment.Description" />
  /// </summary>
  public string Description { get; set; } = string.Empty;
}