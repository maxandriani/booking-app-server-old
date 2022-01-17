using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingApp.Places;

public class PlaceEntityConfiguration : IEntityTypeConfiguration<Place>
{
  public void Configure(EntityTypeBuilder<Place> builder)
  {
    builder.ToTable("places", "places");

    builder.Property(p => p.Name)
      .HasMaxLength(PlaceConstraints.NameMaxLength)
      .HasComment("Nome do local/casa a reservar");

    // Autocomplete performance index
    builder.HasIndex(p => p.Name)
      .IsUnique()
      .HasDatabaseName("places_idx_un_autocomplete");
  }
}