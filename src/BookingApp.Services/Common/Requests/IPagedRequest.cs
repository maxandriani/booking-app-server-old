namespace BookingApp.Common.Requests;

public interface IPagedRequest
{
  int? Take { get; set; }
  int? Page { get; set; }
}
