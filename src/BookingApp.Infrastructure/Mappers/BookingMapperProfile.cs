using AutoMapper;
using BookingApp.Bookings;
using BookingApp.Payments;
using BookingApp.Places;

namespace BookingApp.Mappers;

public class BookingMapperProfile : Profile
{
  public BookingMapperProfile()
  {
    CreateMap<Booking, BookingDto>().ReverseMap();
    CreateMap<CreateUpdateBookingDto, BookingDto>().ReverseMap();
    CreateMap<CreateUpdateBookingDto, Booking>().ReverseMap();

    CreateMap<ContactInfo, ContactInfoDto>().ReverseMap();
    CreateMap<CreateUpdateContactInfoDto, ContactInfoDto>().ReverseMap();
    CreateMap<CreateUpdateContactInfoDto, ContactInfo>().ReverseMap();

    CreateMap<Account, AccountDto>().ReverseMap();
    CreateMap<CreateUpdateAccountDto, Account>().ReverseMap();
    CreateMap<CreateUpdateAccountDto, AccountDto>().ReverseMap();

    CreateMap<Payment, PaymentDto>().ReverseMap();
    CreateMap<CreateUpdatePaymentDto, Payment>().ReverseMap();
    CreateMap<CreateUpdatePaymentDto, PaymentDto>().ReverseMap();

    CreateMap<Place, PlaceDto>().ReverseMap();
    CreateMap<CreateUpdatePlaceDto, Place>().ReverseMap();
    CreateMap<CreateUpdatePlaceDto, PlaceDto>().ReverseMap();
  }
}