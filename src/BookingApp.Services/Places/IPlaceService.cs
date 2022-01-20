using BookingApp.Common;
using BookingApp.Common.Results;

namespace BookingApp.Places;

public interface IPlaceService
{
  Task<PlaceDto> CreateAsync(CreateUpdatePlaceDto input);
  Task DeleteAsync(GetById input);
  Task<PlaceDto> GetByIdAsync(GetById keys);
  Task<CollectionResult<PlaceDto>> GetCollectionAsync(SearchPlaceRequest input);
  Task<PlaceDto> UpdateAsync(GetById keys, CreateUpdatePlaceDto input);
}
