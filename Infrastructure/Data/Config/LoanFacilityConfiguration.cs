using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
  public class LoanConfiguration : IEntityTypeConfiguration<Loan>
  {
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
      builder.Property(l => l.Id).IsRequired();
      builder.Property(l => l.Name).IsRequired().HasMaxLength(30);
      builder.Property(l => l.MinDurationInMonths).IsRequired().HasColumnType("ushort(2)");
      builder.Property(l => l.MaxDurationInMonths).IsRequired().HasColumnType("ushort(2)");
      builder.Property(l => l.MinAmount).IsRequired().HasColumnType("uint(6)");
      builder.Property(l => l.MaxAmount).IsRequired().HasColumnType("uint(6)");


      builder.HasOne(l => l.InterestPerYear).WithMany()
        .HasForeignKey(i => i.InterestPerYearId);
      
      
    }
  }
}