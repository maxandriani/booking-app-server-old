using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingApp.Payments;

public class AccountEntityConfiguration : IEntityTypeConfiguration<Account>
{
  public void Configure(EntityTypeBuilder<Account> builder)
  {
    builder.ToTable("accounts", "payments");

    builder.Property(p => p.Name)
      .HasMaxLength(AccountConstraints.NameMaxLength)
      .HasComment("Nome da conta contábil");

    builder.HasIndex(p => p.Name)
      .IsUnique()
      .HasDatabaseName("accounts_idx_un_name");
  }
}
