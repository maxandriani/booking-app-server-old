using BookingApp.Services.Results;
using BookingApp.Services.Requests;
using BookingApp.Services.Abstractions;

namespace BookingApp.Places;

public interface IPlaceService : ICrudService<PlaceDto, GetByIdRequest, SearchPlaceRequest, CreateUpdatePlaceDto>
{

}
