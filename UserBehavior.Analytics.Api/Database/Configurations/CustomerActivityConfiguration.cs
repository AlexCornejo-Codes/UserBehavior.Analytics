using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserBehavior.Analytics.Api.Entities;

namespace UserBehavior.Analytics.Api.Database.Configurations;

public sealed class CustomerActivityConfiguration : IEntityTypeConfiguration<CustomerActivity>
{
    public void Configure(EntityTypeBuilder<CustomerActivity> builder)
    {
        builder.HasKey(ca => ca.Id);
        builder.Property(ca => ca.Id).HasMaxLength(500);
        
        builder.ToTable("customer_activity");
    }
}
