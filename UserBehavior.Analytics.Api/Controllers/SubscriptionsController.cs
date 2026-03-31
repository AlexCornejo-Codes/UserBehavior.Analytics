using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserBehavior.Analytics.Api.Database;
using UserBehavior.Analytics.Api.DTOs.Subscriptions;
using UserBehavior.Analytics.Api.Entities;

namespace UserBehavior.Analytics.Api.Controllers;

[ApiController]
[Route("subscriptions")]
public sealed class SubscriptionsController(ApplicationDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<SubscriptionsCollectionDto>> GetSubscriptions()
    {
        List<SubscriptionDto> subscriptions = await dbContext
            .Subscriptions
            .Select(SubscriptionQueries.ProjectToDto())
            .ToListAsync();
        
        var subscriptionsCollectionDto = new SubscriptionsCollectionDto
        {
            Data = subscriptions
        };
        
        return Ok(subscriptionsCollectionDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SubscriptionDto>> GetSubscription(string id)
    {
        SubscriptionDto? subscription = await dbContext
            .Subscriptions
            .Where(s => s.Id == id)
            .Select(SubscriptionQueries.ProjectToDto())
            .FirstOrDefaultAsync();

        if (subscription is null)
        {
            return NotFound();
        }
        
        return Ok(subscription);
    }
    
    [HttpPost]
    public async Task<ActionResult<SubscriptionDto>> CreateSubscription(CreateSubscriptionDto createSubscriptionDto)
    {
        Subscription subscription = createSubscriptionDto.ToEntity();
        
        dbContext.Add(subscription);
        await dbContext.SaveChangesAsync();
        
        SubscriptionDto subscriptionDto = subscription.ToDto();
        
        return CreatedAtAction(nameof(GetSubscription), new { id = subscriptionDto.Id }, subscriptionDto);
    }
}
