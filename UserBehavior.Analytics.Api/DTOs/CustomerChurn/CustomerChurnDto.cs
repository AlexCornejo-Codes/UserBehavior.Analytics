namespace UserBehavior.Analytics.Api.DTOs.CustomerChurn;

public sealed record CustomerChurnCollectionDto
{
    public List<CustomerChurnDto> Data { get; init; }
}

public sealed record CustomerChurnDto
{
    public string Id { get; init; }
    public string CustomerId { get; init; }
    public bool Churned { get; init; }
}
