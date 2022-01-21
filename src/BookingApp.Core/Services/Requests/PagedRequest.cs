namespace BookingApp.Services.Requests;

public class PagedRequest : IPagedRequest
{
  public int? Take { get; set; } = 0;
  public int? Page { get; set; } = 0;
}