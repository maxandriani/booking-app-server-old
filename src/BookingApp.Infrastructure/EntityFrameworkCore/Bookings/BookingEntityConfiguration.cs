using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingApp.Bookings;

public class BookingEntityConfiguration : IEntityTypeConfiguration<Booking>
{
  public void Configure(EntityTypeBuilder<Booking> builder)
  {
    builder.ToTable("bookings", "bookings");

    builder.Property(p => p.ReservationCode)
      .HasMaxLength(BookingContraints.ReservationCodeMaxLength)
      .HasComment("Código de reserva externo");

    builder.Property(p => p.ReservedTo)
      .HasMaxLength(BookingContraints.ReservedToMaxLength)
      .HasComment("Nome do responsável");

    builder.Property(p => p.Start)
      .HasColumnType("timestamp without time zone");

    builder.Property(p => p.Finish)
      .HasColumnType("timestamp without time zone");

    
    builder.HasOne(p => p.Place)
      .WithMany()
      .HasForeignKey(p => p.PlaceId)
      .OnDelete(DeleteBehavior.Cascade);

    builder.HasMany(p => p.Contacts)
      .WithOne(p => p.Booking)
      .OnDelete(DeleteBehavior.Cascade);

    builder.HasIndex(p => new { p.PlaceId })
      .HasDatabaseName("booking_idx_place_filter");

    builder.HasIndex(p => new { p.Start, p.Finish })
      .HasDatabaseName("booking_idx_time_search");

    builder.HasIndex(p => new { p.ReservationCode })
      .HasDatabaseName("booking_idx_searh_by_code");

    builder.HasIndex(p => new { p.ReservedTo })
      .HasDatabaseName("booking_idx_search_by_name");
  }
}