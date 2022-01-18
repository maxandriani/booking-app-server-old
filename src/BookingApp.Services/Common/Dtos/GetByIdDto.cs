namespace BookingApp.Common;

public class GetById<TKey>
{
  public TKey? Id { get; set; }
}

public class GetById : GetById<int> {};