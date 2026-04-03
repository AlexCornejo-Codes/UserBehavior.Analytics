using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserBehavior.Analytics.Api.Database;
using UserBehavior.Analytics.Api.DTOs.CustomerChurn;
using UserBehavior.Analytics.Api.Entities;

namespace UserBehavior.Analytics.Api.Controllers;

[ApiController]
[Route("customer-churn")]
public sealed class CustomerChurnController(ApplicationDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<CustomerChurnCollectionDto>> GetAllCustomerChurn()
    {
        List<CustomerChurnDto> churn = await dbContext
            .CustomerChurn
            .Select(CustomerChurnQueries.ProjectToDto())
            .ToListAsync();

        var customerChurnCollectionDto = new CustomerChurnCollectionDto
        {
            Data = churn
        };
        
        return Ok(customerChurnCollectionDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerChurnDto>> GetCustomerChurn(string id)
    {
        CustomerChurnDto? churn = await dbContext
            .CustomerChurn
            .Where(c => c.Id == id)
            .Select(CustomerChurnQueries.ProjectToDto())
            .FirstOrDefaultAsync();

        if (churn is null)
        {
            return NotFound();
        }
        
        return Ok(churn);
    }

    [HttpPost]
    public async Task<ActionResult<CustomerChurnDto>> CreateCustomerChurn(CreateCustomerChurnDto createCustomerChurnDto)
    {
        CustomerChurn customerChurn = createCustomerChurnDto.ToEntity();
        
        dbContext.Add(customerChurn);
        await dbContext.SaveChangesAsync();
        
        CustomerChurnDto customerChurnDto = customerChurn.ToDto();
        
        return CreatedAtAction(nameof(GetCustomerChurn), new { id = customerChurnDto.Id }, customerChurnDto);   
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCustomerChurn(string id, UpdateCustomerChurnDto updateCustomerChurnDto)
    {
        CustomerChurn? churn = await dbContext
            .CustomerChurn
            .FirstOrDefaultAsync(c => c.Id == id);

        if (churn is null)
        {
            return NotFound();
        }
        
        churn.UpdateFromDto(updateCustomerChurnDto);
        await dbContext.SaveChangesAsync();
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCustomerChurn(string id)
    {
        CustomerChurn? churn = await dbContext
            .CustomerChurn
            .FirstOrDefaultAsync(c => c.Id == id);

        if (churn is null)
        {
            return NotFound();
        }
        
        dbContext.Remove(churn);
        await dbContext.SaveChangesAsync();
        
        return NoContent();
    }
}
