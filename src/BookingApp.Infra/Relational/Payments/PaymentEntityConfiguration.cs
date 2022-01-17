using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingApp.Payments;

public class PaymentEntityConfiguration : IEntityTypeConfiguration<Payment>
{
  public void Configure(EntityTypeBuilder<Payment> builder)
  {
    builder.ToTable("payments", "payments");

    builder.Property(p => p.PlaceId)
      .HasComment("Imóvel relacionado a transação.");

    builder.Property(p => p.BookingId)
      .HasComment("Se essa transação está vinculada a uma locação.");

    builder.HasOne(p => p.Place)
      .WithMany()
      .HasForeignKey(p => p.PlaceId)
      .OnDelete(DeleteBehavior.Cascade);

    builder.HasOne(p => p.Booking)
      .WithMany(b => b.Transactions)
      .HasForeignKey(p => p.BookingId)
      .OnDelete(DeleteBehavior.SetNull);

    builder.HasOne(p => p.Account)
      .WithMany()
      .HasForeignKey(p => p.AccountId)
      .OnDelete(DeleteBehavior.Cascade);

    builder.HasIndex(p => new { p.PlaceId, p.When })
      .HasDatabaseName("payments_idx_search_by_place");

    builder.HasIndex(p => new { p.BookingId, p.When })
      .HasDatabaseName("payments_idx_search_by_booking");

    builder.HasIndex(p => new { p.AccountId, p.When })
      .HasDatabaseName("payments_idx_search_by_account");
  }
}
