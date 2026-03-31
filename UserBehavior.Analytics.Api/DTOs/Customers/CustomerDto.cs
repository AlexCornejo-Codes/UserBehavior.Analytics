namespace UserBehavior.Analytics.Api.DTOs.Customers;

public sealed record CustomersCollectionDto
{
    public List<CustomerDto> Data { get; init; }
}

public sealed record CustomerDto
{
    public required string Id { get; init; }
    public required int Age { get; init; }
    public required string Gender { get; init; }
    public required string Country { get; init; }
    public required DateTime CreatedAtUtc { get; init; }
}
