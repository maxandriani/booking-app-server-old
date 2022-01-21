using BookingApp.Services.Results;

namespace BookingApp.Services.Abstractions;

public interface ICollectionable<TGetAllRequest, TOutput>
{
  Task<CollectionResult<TOutput>> GetCollectionAsync(TGetAllRequest input);
}