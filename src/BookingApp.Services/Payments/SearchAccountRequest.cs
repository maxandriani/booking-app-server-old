using BookingApp.Common.Requests;

namespace BookingApp.Payments;

public class SearchAccountDto : PagedAndSortedRequest, ISearchableRequest
{
  /// <summary>
  /// Pesquisa carteira pelo nome.
  /// </summary>
  /// <value></value>
  public string? Search { get; set; }
}