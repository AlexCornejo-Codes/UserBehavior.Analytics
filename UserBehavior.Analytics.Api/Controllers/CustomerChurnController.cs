using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserBehavior.Analytics.Api.Database;
using UserBehavior.Analytics.Api.DTOs.CustomerChurn;

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
}
