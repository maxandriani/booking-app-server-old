using BookingApp.Bookings;
using BookingApp.Payments;
using BookingApp.Places;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.EntityFrameworkCore;

public interface IBookingAppDbContext : IDbContext
{
  DbSet<Booking> Bookings { get; }
  DbSet<ContactInfo> ContactInfos { get; }
  DbSet<Account> Accounts { get; }
  DbSet<Payment> Payments { get; }
  DbSet<Place> Places { get; }
}
