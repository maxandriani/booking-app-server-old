using BookingApp.Bookings;
using BookingApp.Payments;
using BookingApp.Places;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.EntityFrameworkCore;

public class BookingAppDbContext : DbContext, IBookingAppDbContext
{
  public static string ConnectionName = "BookingAppRelational";

  public BookingAppDbContext(DbContextOptions options) : base(options)
  {
  }

  public DbSet<Booking> Bookings => Set<Booking>();
  public DbSet<ContactInfo> ContactInfos => Set<ContactInfo>();
  public DbSet<Account> Accounts => Set<Account>();
  public DbSet<Payment> Payments => Set<Payment>();
  public DbSet<Place> Places => Set<Place>();


  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.ApplyConfiguration<Booking>(new BookingEntityConfiguration());
    modelBuilder.ApplyConfiguration<ContactInfo>(new ContactInfoEntityConfiguration());
    modelBuilder.ApplyConfiguration<Account>(new AccountEntityConfiguration());
    modelBuilder.ApplyConfiguration<Payment>(new PaymentEntityConfiguration());
    modelBuilder.ApplyConfiguration<Place>(new PlaceEntityConfiguration());
  }
}
