using BookingApp.Services.Requests;

namespace BookingApp.Bookings;

public class SearchBookingRequestDto : PagedAndSortedRequest, ISearchableRequest
{
  /// <summary>
  /// Pesquisa pelo nome da reserva
  /// </summary>
  /// <returns></returns>
  public string? Search { get; set; }
  /// <summary>
  /// Filtra resultados de um imóvel apenas
  /// </summary>
  /// <value></value>
  public int? ByPlace { get; set; }
  /// <summary>
  /// Filtra resultados com base em um período.
  /// </summary>
  /// <value></value>
  public DateOnly? Start { get; set; }
  /// <summary>
  /// Filtra resultados com base em um período.
  /// </summary>
  /// <value></value>
  public DateOnly? Finish { get; set; }
  /// <summary>
  /// Pesquisa por uma reserva com base no código de integração.
  /// </summary>
  /// <value></value>
  public string? ReservationCode { get; set; } = string.Empty;
  /// <summary>
  /// Pesquisa por reservas feitas em nome de uma pessoa.
  /// </summary>
  /// <value></value>
  public string? ReservedTo { get; set; } = string.Empty;
}