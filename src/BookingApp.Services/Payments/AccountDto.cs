namespace BookingApp.Payments;

public class AccountDto
{
  /// <summary>
  /// <inheritdoc cref="Account.Id" />
  /// </summary>
  /// <value></value>
  public int Id { get; set; }
  /// <summary>
  /// <inheritdoc cref="Account.Name" />
  /// </summary>
  /// <value></value>
  public string Name { get; set; } = string.Empty;
}