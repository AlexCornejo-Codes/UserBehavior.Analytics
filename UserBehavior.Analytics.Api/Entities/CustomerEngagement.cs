namespace UserBehavior.Analytics.Api.Entities;

public sealed class CustomerEngagement
{
    public string Id { get; set; }
    public string CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int AvgWatchTimeMinutes { get; set; }
    public int WatchSessionsPerWeek { get; set; }
    public decimal CompletionRate { get; set; }
    public int BingeWatchSessions { get; set; }
    public string FavoriteGenre { get; set; }
}
