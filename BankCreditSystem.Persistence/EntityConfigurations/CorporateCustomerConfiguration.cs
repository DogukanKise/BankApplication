using BankCreditSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankCreditSystem.Persistence.EntityConfigurations;

public class CorporateCustomerConfiguration : IEntityTypeConfiguration<CorporateCustomer>
{
    public void Configure(EntityTypeBuilder<CorporateCustomer> builder)
    {
        builder.ToTable("CorporateCustomers");

        builder.Property(c => c.CompanyName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(c => c.TaxNumber)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(c => c.TaxOffice)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.CompanyRegistrationNumber)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(c => c.CommercialTitle)
            .HasMaxLength(250);

        builder.HasIndex(c => c.TaxNumber)
            .IsUnique();
    }
} 