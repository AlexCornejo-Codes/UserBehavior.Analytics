namespace UserBehavior.Analytics.Api.Entities;

public sealed class Subscription
{
    public string Id { get; set; }
    public string CustomerId { get; set; }
    public Customer Customer { get; set; }
    public string SubscriptionType { get; set; }
    public decimal MonthlyFee { get; set; }
    public string PaymentMethod { get; set; }
    public int AccountAgeMonths { get; set; }
}
