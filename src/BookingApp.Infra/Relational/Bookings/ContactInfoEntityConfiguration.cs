using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingApp.Bookings;

public class ContactInfoEntityConfiguration : IEntityTypeConfiguration<ContactInfo>
{
  public void Configure(EntityTypeBuilder<ContactInfo> builder)
  {
    builder.ToTable("contact_info", "bookings");

    builder.Property(p => p.Kind)
      .HasMaxLength(ContactInfoConstraints.KindMaxLength)
      .HasComment("Tipo de contato relacionado");

    builder.Property(p => p.Value)
      .HasMaxLength(ContactInfoConstraints.ValueMaxLength)
      .HasComment("Dado do contato");

    builder.HasOne(p => p.Booking)
      .WithMany(p => p.Contacts)
      .HasForeignKey(p => p.BookingId)
      .OnDelete(DeleteBehavior.Cascade);
  }
}
