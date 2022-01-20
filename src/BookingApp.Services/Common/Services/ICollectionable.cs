using BookingApp.Common.Results;

namespace BookingApp.Services;

public interface ICollectionable<TGetAllRequest, TOutput>
{
  Task<CollectionResult<TOutput>> GetCollectionAsync(TGetAllRequest input);
}