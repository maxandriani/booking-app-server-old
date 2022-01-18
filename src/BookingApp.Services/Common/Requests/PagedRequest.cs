namespace BookingApp.Common.Requests;

public class PagedRequest : IPagedRequest
{
  public int? Take { get; set; } = int.MaxValue;
  public int? Page { get; set; } = 0;
}