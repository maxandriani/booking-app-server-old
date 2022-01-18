using BookingApp.Common.Requests;

namespace BookingApp.Payments;

public class SearchPaymentDto : PagedAndSortedRequest, ISearchableRequest
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
  public DateOnly? DateStart { get; set; }
  /// <summary>
  /// Date range to search
  /// </summary>
  /// <value></value>
  public DateOnly? DateFinish { get; set; }
}
