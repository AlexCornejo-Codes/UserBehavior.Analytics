namespace UserBehavior.Analytics.Api.DTOs.CustomerEngagement;

public sealed record UpdateCustomerEngagement
{
    public required int AvgWatchTimeMinutes { get; init; }
    public required int WatchSessionsPerWeek { get; init; }
    public required decimal CompletionRate { get; init; }
    public required int BingeWatchSessions { get; init; }
    public required string FavoriteGenre { get; init; }
}
