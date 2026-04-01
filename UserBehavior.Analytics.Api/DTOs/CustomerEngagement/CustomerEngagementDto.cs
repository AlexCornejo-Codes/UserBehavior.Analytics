namespace UserBehavior.Analytics.Api.DTOs.CustomerEngagement;

public sealed record CustomersEngagementCollectionDto
{
    public List<CustomerEngagementDto> Data { get; init; }
}

public sealed record CustomerEngagementDto
{
    public string Id { get; init; }
    public string CustomerId { get; init; }
    public int AvgWatchTimeMinutes { get; init; }
    public int WatchSessionsPerWeek { get; init; }
    public decimal CompletionRate { get; init; }
    public int BingeWatchSessions { get; init; }
    public string FavoriteGenre { get; init; }
}
