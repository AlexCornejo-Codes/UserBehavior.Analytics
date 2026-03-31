namespace UserBehavior.Analytics.Api.DTOs.Subscriptions;

public sealed record UpdateSubscriptionDto
{
    public required string SubscriptionType { get; init; }
    public required decimal MonthlyFee { get; init; }
    public required string PaymentMethod { get; init; }
    public required int AccountAgeMonths { get; init; }
}
