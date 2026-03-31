namespace UserBehavior.Analytics.Api.DTOs.Customers;

public sealed record CreateCustomerDto
{
    public required int Age { get; init; }
    public required string Gender { get; init; }
    public required string Country { get; init; }
}
