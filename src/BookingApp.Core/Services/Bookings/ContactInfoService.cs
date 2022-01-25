using AutoMapper;
using BookingApp.Data;
using BookingApp.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookingApp.Bookings;

public class ContactInfoService :
  CrudService<ContactInfo, ContactInfoDto, ContactInfoKeysDto, SearchContactInfoRequest, CreateUpdateContactInfoDto>,
  IContactInfoService
{
  public ContactInfoService(ILogger<ContactInfoService> logger, IMapper mapper, IBookingAppDbContext dbContext) : base(logger, mapper, dbContext)
  {
  }

  protected override IQueryable<ContactInfo> CreateCollectionQuery(IQueryable<ContactInfo> query, SearchContactInfoRequest input)
  {
    if (input.BookingId > 0)
      query = query.Where(q => q.BookingId == input.BookingId);

    if (!string.IsNullOrEmpty(input.Search))
      query = query.Where(q => q.Kind.ToLower() == input.Search.ToLower() || q.Value.ToLower().Contains(input.Search.ToLower()));
    
    return query;
  }

  protected override IQueryable<ContactInfo> DefaultSorting(IQueryable<ContactInfo> query)
    => query
      .OrderBy(q => q.Kind)
      .ThenBy(q => q.Value);

  protected override ContactInfo GetEntityById(ContactInfoKeysDto keys)
    => DbSet.First(q => q.Id == keys.Id && q.BookingId == keys.BookingId);
}