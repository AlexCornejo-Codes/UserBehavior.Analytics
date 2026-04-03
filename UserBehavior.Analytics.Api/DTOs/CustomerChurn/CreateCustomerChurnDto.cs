namespace UserBehavior.Analytics.Api.DTOs.CustomerChurn;

public sealed record CreateCustomerChurnDto
{
    public required string CustomerId { get; init; }
    public required bool Churned { get; init; }
}
