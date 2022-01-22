using AutoMapper;
using BookingApp.Data;
using BookingApp.Services.Abstractions;
using BookingApp.Services.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookingApp.Payments;

public class PaymentService:
  CrudService<Payment, PaymentDto, GetByIdRequest, SearchPaymentRequest, CreateUpdatePaymentDto>,
  IPaymentService
{
  public PaymentService(ILogger<PaymentService> logger, IMapper mapper, IBookingAppDbContext dbContext) : base(logger, mapper, dbContext)
  {
  }

  public async Task<PaymentDto> ConfirmAsync(GetByIdRequest payment, ConfirmPaymentDto confirmation)
  {
    var entity = GetEntityById(payment);
    entity.ConfirmedAt = confirmation.ConfirmedAt ?? DateTime.Now;
    // Todo: Validate Business
    DbSet.Update(entity);
    await DbContext.SaveChangesAsync();
    return MapToOutput(entity);
  }

  public async Task<PaymentDto> UnConfirmAsync(GetByIdRequest payment)
  {
    var entity = GetEntityById(payment);
    entity.ConfirmedAt = null;
    // Todo: Validate Business
    DbSet.Update(entity);
    await DbContext.SaveChangesAsync();
    return MapToOutput(entity);
  }

  protected override IQueryable<Payment> CreateCollectionQuery(IQueryable<Payment> query, SearchPaymentRequest input)
  {
    if (input.DateFinish.HasValue && input.DateFinish.HasValue && input.DateFinish > input.DateStart) {
      throw new ArgumentException($"Data Final não pode ser inferior a Data Inicial. {input.DateStart} / {input.DateFinish}.");
    }

    query = query
      .Include(p => p.Booking)
      .Include(p => p.Place)
      .Include(p => p.Account);

    if (input.DateStart.HasValue)
      query = query.Where(p => p.When >= input.DateStart.Value.Date);

    if (input.DateFinish.HasValue)
      query = query.Where(p => p.When <= input.DateFinish.Value.Date.AddDays(1).AddMilliseconds(-1));

    if (input.Confirmed.HasValue)
    {
      if (input.Confirmed == true)
      {
        query = query.Where(p => p.ConfirmedAt != null);
      }
      else
      {
        query = query.Where(p => p.ConfirmedAt == null);
      }
    }

    if (input.ByPlace.HasValue)
      query = query.Where(p => p.PlaceId == input.ByPlace);

    if (input.ByAccount.HasValue)
      query = query.Where(p => p.AccountId == input.ByAccount);

    if (input.ByBooking.HasValue)
      query = query.Where(p => p.BookingId == input.ByBooking);

    if (!string.IsNullOrEmpty(input.Search))
      query = query.Where(p => p.Description.ToLower().Contains(input.Search.ToLower()));

    return query;
  }

  protected override IQueryable<Payment> DefaultSorting(IQueryable<Payment> query)
    => query.OrderByDescending(p => p.When);

  protected override Payment GetEntityById(GetByIdRequest keys)
    => DbSet.First(p => p.Id == keys.Id);
}