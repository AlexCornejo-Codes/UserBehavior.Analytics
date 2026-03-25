namespace UserBehavior.Analytics.Api.Entities;

public sealed class Customer
{
    public string Id  { get; set; }
    public string ExternalCustomerId { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public DateTime CreatedAtUtc { get; set; }
}
