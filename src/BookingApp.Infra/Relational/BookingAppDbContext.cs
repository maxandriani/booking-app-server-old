using BookingApp.Bookings;
using BookingApp.Payments;
using BookingApp.Places;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Relational;

public class BookingAppDbContext : DbContext
{
  public static string ConnectionName = "BookingAppRelational";

  public BookingAppDbContext(DbContextOptions options) : base(options)
  {
  }

  public DbSet<Booking>? Bookings { get; set; }
  public DbSet<ContactInfo>? ContactInfos { get; set; }
  public DbSet<Account>? Accounts { get; set; }
  public DbSet<Payment>? Payments { get; set; }
  public DbSet<Place>? Places { get; set; }


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
