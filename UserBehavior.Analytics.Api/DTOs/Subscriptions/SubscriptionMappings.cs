using UserBehavior.Analytics.Api.Entities;

namespace UserBehavior.Analytics.Api.DTOs.Subscriptions;

internal static class SubscriptionMappings
{
    public static SubscriptionDto ToDto(this Subscription subscription)
    {
        return new SubscriptionDto
        {
            Id = subscription.Id,
            CustomerId = subscription.CustomerId,
            SubscriptionType = subscription.SubscriptionType,
            MonthlyFee = subscription.MonthlyFee,
            PaymentMethod = subscription.PaymentMethod,
            AccountAgeMonths = subscription.AccountAgeMonths
        };
    }
}
