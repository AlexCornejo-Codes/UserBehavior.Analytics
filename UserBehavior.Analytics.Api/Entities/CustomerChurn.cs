namespace UserBehavior.Analytics.Api.Entities;

public sealed class CustomerChurn
{
    public string Id { get; set; }
    public string CustomerId { get; set; }
    public Customer Customer { get; set; }
    public bool Churned { get; set; }
}
