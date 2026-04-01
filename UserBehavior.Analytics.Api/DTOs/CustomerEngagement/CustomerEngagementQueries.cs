using System.Linq.Expressions;

namespace UserBehavior.Analytics.Api.DTOs.CustomerEngagement;

internal static class CustomerEngagementQueries
{
    public static Expression<Func<Entities.CustomerEngagement, CustomerEngagementDto>> ProjectToDto()
    {
        return ce => new CustomerEngagementDto
        {
            Id = ce.Id,
            CustomerId = ce.CustomerId,
            AvgWatchTimeMinutes = ce.AvgWatchTimeMinutes,
            WatchSessionsPerWeek = ce.WatchSessionsPerWeek,
            CompletionRate = ce.CompletionRate,
            BingeWatchSessions = ce.BingeWatchSessions,
            FavoriteGenre = ce.FavoriteGenre,
        };
    }
}
