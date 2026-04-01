namespace UserBehavior.Analytics.Api.DTOs.CustomerEngagement;

internal static class CustomerEngagementMappings
{
    public static CustomerEngagementDto ToDto(this Entities.CustomerEngagement customerEngagement)
    {
        return new CustomerEngagementDto
        {
            Id = customerEngagement.Id,
            CustomerId = customerEngagement.CustomerId,
            AvgWatchTimeMinutes = customerEngagement.AvgWatchTimeMinutes,
            WatchSessionsPerWeek = customerEngagement.WatchSessionsPerWeek,
            CompletionRate = customerEngagement.CompletionRate,
            BingeWatchSessions = customerEngagement.BingeWatchSessions,
            FavoriteGenre = customerEngagement.FavoriteGenre,
        };
    }
    
    public static Entities.CustomerEngagement ToEntity(this CreateCustomerEngagement dto)
    {
        return new Entities.CustomerEngagement
        {
            Id = $"ce_{Guid.CreateVersion7()}",
            CustomerId = dto.CustomerId,
            AvgWatchTimeMinutes = dto.AvgWatchTimeMinutes,
            WatchSessionsPerWeek = dto.WatchSessionsPerWeek,
            CompletionRate = dto.CompletionRate,
            BingeWatchSessions = dto.BingeWatchSessions,
            FavoriteGenre = dto.FavoriteGenre
        };
    }
    
    public static void UpdateFromDto(this Entities.CustomerEngagement customerEngagement, UpdateCustomerEngagement dto)
    {
        customerEngagement.AvgWatchTimeMinutes = dto.AvgWatchTimeMinutes;
        customerEngagement.WatchSessionsPerWeek = dto.WatchSessionsPerWeek;
        customerEngagement.CompletionRate = dto.CompletionRate;
        customerEngagement.BingeWatchSessions = dto.BingeWatchSessions;
        customerEngagement.FavoriteGenre = dto.FavoriteGenre;
    }
}
