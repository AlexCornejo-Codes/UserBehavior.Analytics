using System.Linq.Expressions;
using UserBehavior.Analytics.Api.Entities;

namespace UserBehavior.Analytics.Api.DTOs.Subscriptions;

internal static class SubscriptionQueries
{
    public static Expression<Func<Subscription, SubscriptionDto>> ProjectToDto()
    {
        return s => new SubscriptionDto
        {
            Id = s.Id,
            CustomerId = s.CustomerId,
            SubscriptionType = s.SubscriptionType,
            MonthlyFee = s.MonthlyFee,
            PaymentMethod = s.PaymentMethod,
            AccountAgeMonths = s.AccountAgeMonths
        };}
}
