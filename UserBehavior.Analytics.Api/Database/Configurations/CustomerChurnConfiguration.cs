using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserBehavior.Analytics.Api.Entities;

namespace UserBehavior.Analytics.Api.Database.Configurations;

public sealed class CustomerChurnConfiguration : IEntityTypeConfiguration<CustomerChurn>
{
    public void Configure(EntityTypeBuilder<CustomerChurn> builder)
    {
        builder.HasKey(cc => cc.Id);
        builder.Property(cc => cc.Id).HasMaxLength(500);
        
        builder.ToTable("customer_churn");
    }
}
