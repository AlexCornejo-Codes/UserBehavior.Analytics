using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserBehavior.Analytics.Api.Database;
using UserBehavior.Analytics.Api.DTOs.CustomerEngagement;

namespace UserBehavior.Analytics.Api.Controllers;

[ApiController]
[Route("customer-engagement")]
public sealed class CustomerEngagementController(ApplicationDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<CustomersEngagementCollectionDto>> GetAllCustomerEngagement()
    {
        List<CustomerEngagementDto> engagement = await dbContext
            .CustomerEngagement
            .Select(CustomerEngagementQueries.ProjectToDto())
            .ToListAsync();

        var customerEngagementCollectionDto = new CustomersEngagementCollectionDto
        {
            Data = engagement
        };
        
        return Ok(customerEngagementCollectionDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerEngagementDto>> GetCustomerEngagement(string id)
    {
        CustomerEngagementDto? engagement = await dbContext
            .CustomerEngagement
            .Where(ce => ce.Id == id)
            .Select(CustomerEngagementQueries.ProjectToDto())
            .FirstOrDefaultAsync();

        if (engagement is null)
        {
            return NotFound();
        }

        return Ok(engagement);
    }
}
