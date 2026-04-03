using System.Linq.Expressions;

namespace UserBehavior.Analytics.Api.DTOs.CustomerChurn;

internal static class CustomerChurnQueries
{
    public static Expression<Func<Entities.CustomerChurn, CustomerChurnDto>> ProjectToDto()
    {
        return cc => new CustomerChurnDto
        {
            Id = cc.Id,
            CustomerId = cc.CustomerId,
            Churned = cc.Churned
        };
    }
}
