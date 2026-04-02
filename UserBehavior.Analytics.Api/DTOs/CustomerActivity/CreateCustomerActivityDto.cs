namespace UserBehavior.Analytics.Api.DTOs.CustomerActivity;

public sealed record CreateCustomerActivityDto
{
    public required string CustomerId { get; init; }
    public required int LastLoginDays { get; init; }
    public required int Interactions { get; init; }
    public required decimal RecommendationClickRate { get; init; }
}
