using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserBehavior.Analytics.Api.Database;
using UserBehavior.Analytics.Api.DTOs.CustomerEngagement;
using UserBehavior.Analytics.Api.Entities;

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
    
    [HttpPost]
    public async Task<ActionResult<CustomerEngagementDto>> CreateCustomerEngagement(CreateCustomerEngagement createCustomerEngagementDto)
    {
        CustomerEngagement customerEngagement = createCustomerEngagementDto.ToEntity();

        dbContext.Add(customerEngagement);
        await dbContext.SaveChangesAsync();

        CustomerEngagementDto customerEngagementDto = customerEngagement.ToDto();
        
        return CreatedAtAction(nameof(GetCustomerEngagement), new { id = customerEngagementDto.Id }, customerEngagementDto);
    }
}
