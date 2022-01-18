using BookingApp.Common.Requests;

namespace BookingApp.Places;

public class SearchPlaceRequest : PagedAndSortedRequest, ISearchableRequest
{
  /// <summary>
  /// Pesquisar Locais pela descrição.
  /// </summary>
  /// <returns></returns>
  public string? Search { get; set; }
}