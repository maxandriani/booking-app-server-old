using AutoMapper;
using BookingApp.Data;
using BookingApp.Services.Abstractions;
using BookingApp.Services.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookingApp.Bookings;

public class BookingService :
  CrudService<Booking, BookingDto, GetByIdRequest, SearchBookingRequestDto, CreateUpdateBookingDto>,
  IBookingService
{
  public BookingService(ILogger<BookingService> logger, IMapper mapper, IBookingAppDbContext dbContext) : base(logger, mapper, dbContext)
  {
  }

  protected override IQueryable<Booking> CreateCollectionQuery(IQueryable<Booking> query, SearchBookingRequestDto input)
  {
    if (input.Start.HasValue && input.Finish.HasValue && input.Start > input.Finish)
    {
      throw new ArgumentException($"A data inicial não pode ser superior a data final. {input.Start} / {input.Finish}");
    }

    query = query
      .Include(p => p.Place);

    if (input.WithTransactions == true)
      query = query.Include(p => p.Transactions);

    if (input.Start.HasValue)
      query = query.Where(p => p.Start >= input.Start);

    if (input.Finish.HasValue)
      query = query.Where(p => p.Finish <= input.Finish);

    if (input.ByPlace.HasValue)
      query = query.Where(p => p.PlaceId == input.ByPlace);

    if (!string.IsNullOrEmpty(input.ReservationCode))
      query = query.Where(p => p.ReservationCode.ToLower().Contains(input.ReservationCode.ToLower()));
    
    if (!string.IsNullOrEmpty(input.ReservedTo))
      query = query.Where(p => p.ReservedTo.ToLower().Contains(input.ReservedTo.ToLower()));

    if (!string.IsNullOrEmpty(input.Search))
      query = query.Where(p => p.ReservedTo.ToLower().Contains(input.Search.ToLower()) || p.ReservationCode.ToLower().Contains(input.Search.ToLower()));
    
    return query;
  }

  protected override IQueryable<Booking> DefaultSorting(IQueryable<Booking> query)
    => query.OrderByDescending(p => p.Start)
      .ThenByDescending(p => p.Finish);

  protected override Booking GetEntityById(GetByIdRequest keys) => DbSet.First(p => p.Id == keys.Id);
}