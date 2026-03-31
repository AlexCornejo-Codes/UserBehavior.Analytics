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

    public static Subscription ToEntity(this CreateSubscriptionDto dto)
    {
        Subscription subscription = new()
        {
            Id = $"s_{Guid.CreateVersion7()}",
            CustomerId = dto.CustomerId,
            SubscriptionType = dto.SubscriptionType,
            MonthlyFee = dto.MonthlyFee,
            PaymentMethod = dto.PaymentMethod,
            AccountAgeMonths = dto.AccountAgeMonths
        };
        
        return subscription;
    }
    
    public static void UpdateFromDto(this Subscription subscription, UpdateSubscriptionDto dto)
    {
        subscription.SubscriptionType = dto.SubscriptionType;
        subscription.MonthlyFee = dto.MonthlyFee;
        subscription.PaymentMethod = dto.PaymentMethod;
        subscription.AccountAgeMonths = dto.AccountAgeMonths;
    }
}
