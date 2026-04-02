namespace UserBehavior.Analytics.Api.Entities;

public sealed class CustomerActivity
{
    public string Id { get; set; }
    public string CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int LastLoginDays { get; set; }
    public int Interactions { get; set; }
    public decimal RecommendationClickRate { get; set; }
}
