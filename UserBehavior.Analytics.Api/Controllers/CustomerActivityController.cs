using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserBehavior.Analytics.Api.Database;
using UserBehavior.Analytics.Api.DTOs.CustomerActivity;
using UserBehavior.Analytics.Api.Entities;

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
    public async Task<ActionResult<CustomerActivityDto>> GetCustomerActivity(string id)
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
    
    [HttpPost]
    public async Task<ActionResult<CustomerActivityDto>> CreateCustomerActivity(CreateCustomerActivityDto dto)
    {
        CustomerActivity customerActivity = dto.ToEntity();
        
        dbContext.Add(customerActivity);
        await dbContext.SaveChangesAsync();
        
        CustomerActivityDto customerActivityDto = customerActivity.ToDto();
        
        return CreatedAtAction(nameof(GetCustomerActivity), new { id = customerActivityDto.Id }, customerActivityDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCustomerActivity(string id, UpdateCustomerActivityDto updateCustomerActivityDto)
    {
        CustomerActivity? customerActivity = await dbContext
            .CustomerActivity
            .FirstOrDefaultAsync(ca => ca.Id == id);

        if (customerActivity is null)
        {
            return NotFound();
        }
        
        customerActivity.UpdateFromDto(updateCustomerActivityDto);
        await dbContext.SaveChangesAsync();
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCustomerActivity(string id)
    {
        CustomerActivity? customerActivity = await dbContext
            .CustomerActivity
            .FirstOrDefaultAsync(ca => ca.Id == id);
        
        if (customerActivity is null)
        {
            return NotFound();
        }
        
        dbContext.Remove(customerActivity);
        await dbContext.SaveChangesAsync();
        
        return NoContent();
    }
}
