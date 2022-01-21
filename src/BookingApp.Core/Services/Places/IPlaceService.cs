using BookingApp.Services.Results;
using BookingApp.Services.Requests;

namespace BookingApp.Places;

public interface IPlaceService
{
  Task<PlaceDto> CreateAsync(CreateUpdatePlaceDto input);
  Task DeleteAsync(GetByIdRequest input);
  Task<PlaceDto> GetByIdAsync(GetByIdRequest keys);
  Task<CollectionResult<PlaceDto>> GetCollectionAsync(SearchPlaceRequest input);
  Task<PlaceDto> UpdateAsync(GetByIdRequest keys, CreateUpdatePlaceDto input);
}
