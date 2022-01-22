using BookingApp.Services.Results;

namespace BookingApp.Services.Abstractions;

public interface IReadOnlyService<TEntityDto, TKey, TSearchRequest> :
  IReadable<TKey, TEntityDto>,
  ICollectionable<TSearchRequest, TEntityDto>
{
}
