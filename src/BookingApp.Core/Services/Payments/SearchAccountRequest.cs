using BookingApp.Services.Requests;

namespace BookingApp.Payments;

public class SearchAccountRequest : PagedAndSortedRequest, ISearchableRequest
{
  /// <summary>
  /// Pesquisa carteira pelo nome.
  /// </summary>
  /// <value></value>
  public string? Search { get; set; }
}