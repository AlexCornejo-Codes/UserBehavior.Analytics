using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserBehavior.Analytics.Api.Entities;

namespace UserBehavior.Analytics.Api.Database.Configurations;

public sealed class CustomerEngagementConfiguration : IEntityTypeConfiguration<CustomerEngagement>
{
    public void Configure(EntityTypeBuilder<CustomerEngagement> builder)
    {
        builder.HasKey(ce => ce.Id);
        builder.Property(ce => ce.Id).HasMaxLength(500);
    }
}
