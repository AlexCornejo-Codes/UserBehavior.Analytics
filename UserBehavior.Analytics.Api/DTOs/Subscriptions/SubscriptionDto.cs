namespace UserBehavior.Analytics.Api.DTOs.Subscriptions;

public sealed record SubscriptionDto
{
    public string Id { get; init; }
    public string CustomerId { get; init; }
    public string SubscriptionType { get; init; }
    public decimal MonthlyFee { get; init; }
    public string PaymentMethod { get; init; }
    public int AccountAgeMonths { get; init; }
}
