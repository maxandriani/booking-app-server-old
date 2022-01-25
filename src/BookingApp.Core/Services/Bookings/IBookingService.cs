using BookingApp.Services.Abstractions;
using BookingApp.Services.Requests;

namespace BookingApp.Bookings;

public interface IBookingService :
  ICrudService<BookingDto, GetByIdRequest, SearchBookingRequestDto, CreateUpdateBookingDto>
{}
