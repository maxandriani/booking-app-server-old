namespace BookingApp.Services.Requests;

public class GetByIdRequest<TKey>
{
  public TKey? Id { get; set; }
}

public class GetByIdRequest : GetByIdRequest<int> {};