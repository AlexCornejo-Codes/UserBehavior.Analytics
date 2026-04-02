using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserBehavior.Analytics.Api.Database;
using UserBehavior.Analytics.Api.DTOs.CustomerActivity;

namespace UserBehavior.Analytics.Api.Controllers;

[ApiController]
[Route("customer-activity")]
public class CustomerActivityController(ApplicationDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<CustomerActivityCollectionDto>> GetAllCustomerActivity()
    {
        List<CustomerActivityDto> customerActivity = await dbContext
            .CustomerActivity
            .Select(CustomerActivityQueries.ProjectToDto())
            .ToListAsync();

        var customerActivityCollectionDto = new CustomerActivityCollectionDto
        {
            Data = customerActivity
        };

        return Ok(customerActivityCollectionDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerActivityDto>> GetCustomerActivityById(string id)
    {
        CustomerActivityDto? customerActivity = await dbContext
            .CustomerActivity
            .Where(ca => ca.Id == id)
            .Select(CustomerActivityQueries.ProjectToDto())
            .FirstOrDefaultAsync();
        
        if (customerActivity is null)
        {
            return NotFound();
        }
        
        return Ok(customerActivity);
    }
}
