namespace BookingApp.Bookings;

public class ContactInfo
{
  public int Id { get; set; }
  public int BookingId { get; set; }
  public Booking? Booking { get; set; }
  
  /// <summary>
  /// What kind of contact is: airbnb | email | phone ...
  /// </summary>
  public string Kind { get; set; } = string.Empty;
  /// <summary>
  /// The contact info: email: jonas@brother.com
  /// </summary>
  public string Value { get; set; } = string.Empty;
}
