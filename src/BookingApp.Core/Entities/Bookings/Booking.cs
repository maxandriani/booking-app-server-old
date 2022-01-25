using BookingApp.Payments;
using BookingApp.Places;

namespace BookingApp.Bookings;

/// <summary>
/// Booking record
/// </summary>
public class Booking
{
  public int Id { get; set; }
  /// <summary>
  /// What place should be blocked?
  /// </summary>
  public int PlaceId { get; set; }
  /// <summary>
  /// <inheritdoc cref="Booking.PlaceId"/>
  /// </summary>  
  public Place? Place { get; set; }
  /// <summary>
  /// When this reservaion starts
  /// </summary>
  public DateTime Start { get; set; }
  /// <summary>
  /// When this reservation finishes
  /// </summary>
  public DateTime Finish { get; set; }
  /// <summary>
  /// Channel reservation Code
  /// </summary>
  public string ReservationCode { get; set; } = string.Empty;
  /// <summary>
  /// Who is the person that will take this reservation
  /// </summary>
  public string ReservedTo { get; set; } = string.Empty;

  public ICollection<ContactInfo> Contacts { get; set; } = new List<ContactInfo>();

  public ICollection<Payment> Transactions { get; set; } = new List<Payment>();
}
