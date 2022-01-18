namespace BookingApp.Payments;

public class CreateUpdateAccountDto
{
  /// <summary>
  /// <inheritdoc cref="Account.Name" />
  /// </summary>
  /// <value></value>
  public string Name { get; set; } = string.Empty;
}