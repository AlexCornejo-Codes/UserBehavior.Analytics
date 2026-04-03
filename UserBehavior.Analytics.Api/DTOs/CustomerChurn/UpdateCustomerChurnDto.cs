namespace UserBehavior.Analytics.Api.DTOs.CustomerChurn;

public sealed record UpdateCustomerChurnDto
{
    public required bool Churned { get; init; }
}
