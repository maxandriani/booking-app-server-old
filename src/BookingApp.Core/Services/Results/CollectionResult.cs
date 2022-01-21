namespace BookingApp.Services.Results;

public class CollectionResult<TType>
{
  public CollectionResult()
  {
  }

  public CollectionResult(List<TType> data, int totalCount) : this()
  {
    Result = data;
    TotalCount = totalCount;
  }

  public List<TType> Result { get; set; } = new List<TType>();
  public int TotalCount { get; set; }
}