namespace UserBehavior.Analytics.Api.DTOs.CustomerActivity;

public sealed record CustomerActivityCollectionDto
{
    public List<CustomerActivityDto> Data { get; init; }
}

public sealed record CustomerActivityDto
{
    public string Id { get; init; }
    public string CustomerId { get; init; }
    public int LastLoginDays { get; init; }
    public int Interactions { get; init; }
    public decimal RecommendationClickRate { get; init; }
}
