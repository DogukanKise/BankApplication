using BankCreditSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankCreditSystem.Persistence.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.PhoneNumber)
            .HasMaxLength(20)
            .IsRequired();
            
        builder.Property(c => c.Email)
            .HasMaxLength(100)
            .IsRequired();
            
        builder.Property(c => c.Address)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(c => c.IsActive)
            .HasDefaultValue(true);
    }
} 