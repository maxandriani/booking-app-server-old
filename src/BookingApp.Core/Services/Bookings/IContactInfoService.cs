using BookingApp.Services.Abstractions;

namespace BookingApp.Bookings;

public interface IContactInfoService :
  ICrudService<ContactInfoDto, ContactInfoKeysDto, SearchContactInfoRequest, CreateUpdateContactInfoDto>
{}
