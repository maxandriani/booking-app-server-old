namespace BookingApp.Services.Results;

public class CollectionResult<TType>
{
  public CollectionResult(IEnumerable<TType> data, int totalCount)
  {
    Result = data;
    TotalCount = totalCount;
  }

  public IEnumerable<TType> Result { get; set; }
  public int TotalCount { get; set; }
}