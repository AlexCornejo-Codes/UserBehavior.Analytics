namespace UserBehavior.Analytics.Api.DTOs.CustomerActivity;

internal static class CustomerActivityMappings
{
    public static CustomerActivityDto ToDto(this Entities.CustomerActivity customerActivity)
    {
        return new CustomerActivityDto
        {
            Id = customerActivity.Id,
            CustomerId = customerActivity.CustomerId,
            LastLoginDays = customerActivity.LastLoginDays,
            Interactions = customerActivity.Interactions,
            RecommendationClickRate = customerActivity.RecommendationClickRate
        };
    }
    
    public static Entities.CustomerActivity ToEntity(this CreateCustomerActivityDto dto)
    {
        return new Entities.CustomerActivity
        {
            Id = $"ca_{Guid.CreateVersion7()}",
            CustomerId = dto.CustomerId,
            LastLoginDays = dto.LastLoginDays,
            Interactions = dto.Interactions,
            RecommendationClickRate = dto.RecommendationClickRate
        };
    }
    
    public static void UpdateFromDto(this Entities.CustomerActivity customerActivity, UpdateCustomerActivityDto dto)
    {
        customerActivity.LastLoginDays = dto.LastLoginDays;
        customerActivity.Interactions = dto.Interactions;
        customerActivity.RecommendationClickRate = dto.RecommendationClickRate;
    }
}
