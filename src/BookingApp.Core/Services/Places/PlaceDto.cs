namespace BookingApp.Places;

public class PlaceDto
{
  public int Id { get; set; }
  /// <summary>
  /// <inheritdoc cref="Place.Name" />
  /// </summary>
  /// <value></value>
  public string Name { get; set; } = string.Empty;
}