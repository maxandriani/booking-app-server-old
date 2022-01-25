namespace BookingApp.Bookings.v1;

public class BookingContactInfoCreateUpdateRequest
{
  /// <summary>
  /// <inheritdoc cref="ContactInfo.Kind" /> 
  /// </summary>
  public string Kind { get; set; } = string.Empty;
  /// <summary>
  /// <inheritdoc cref="ContactInfo.Value" />
  /// </summary>
  public string Value { get; set; } = string.Empty;
}