using BookingApp.Services.Requests;

namespace BookingApp.Payments;

public class SearchPaymentRequest : PagedAndSortedRequest, ISearchableRequest
{
  /// <summary>
  /// Pesquisa pagamentos com base na descrição, nome do imóvel ou nome da reserva.
  /// Problemas de performance.
  /// </summary>
  /// <value></value>
  public string? Search { get; set; }
  /// <summary>
  /// Filtra pagamentos de um imóvel específico.
  /// </summary>
  /// <value></value>
  public int? ByPlace { get; set; }
  /// <summary>
  /// Filtra pagamentos de uma reserva específica.
  /// </summary>
  /// <value></value>
  public int? ByBooking { get; set; }
  /// <summary>
  /// Filtra pagamentos de uma carteira específica.
  /// </summary>
  /// <value></value>
  public int? ByAccount { get; set; }
  /// <summary>
  /// Filtra apenas os lançamentos confirmados.
  /// </summary>
  /// <value></value>
  public bool? Confirmed { get; set; }
  /// <summary>
  /// Date range to search
  /// </summary>
  /// <value></value>
  public DateTime? DateStart { get; set; }
  /// <summary>
  /// Date range to search
  /// </summary>
  /// <value></value>
  public DateTime? DateFinish { get; set; }
}
