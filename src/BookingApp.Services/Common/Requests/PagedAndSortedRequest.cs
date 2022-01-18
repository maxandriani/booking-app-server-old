namespace BookingApp.Common.Requests;

public class PagedAndSortedRequest : IPagedRequest, ISortedRequest
{
  public int? Take { get; set; } = int.MaxValue;
  public int? Page { get; set; } = 0;
  public string? Sorting { get; set; }
}