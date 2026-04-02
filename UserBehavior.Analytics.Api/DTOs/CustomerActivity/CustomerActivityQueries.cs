using System.Linq.Expressions;

namespace UserBehavior.Analytics.Api.DTOs.CustomerActivity;

internal static class CustomerActivityQueries
{
    public static Expression<Func<Entities.CustomerActivity, CustomerActivityDto>> ProjectToDto()
    {
        return ca => new CustomerActivityDto
        {
            Id = ca.Id,
            CustomerId = ca.CustomerId,
            LastLoginDays = ca.LastLoginDays,
            Interactions = ca.Interactions,
            RecommendationClickRate = ca.RecommendationClickRate
        };
    }
}
