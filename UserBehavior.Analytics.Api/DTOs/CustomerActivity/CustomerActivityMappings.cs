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
}
