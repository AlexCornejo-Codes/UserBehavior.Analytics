using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserBehavior.Analytics.Api.Database;
using UserBehavior.Analytics.Api.DTOs.Customers;

namespace UserBehavior.Analytics.Api.Controllers;

[ApiController]
[Route("customers")]
public sealed class CustomersController(ApplicationDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<CustomersCollectionDto>> GetCustomers()
    {
        List<CustomerDto> customers = await dbContext
            .Customers
            .Select(c => new CustomerDto
            {
                Id = c.Id,
                ExternalCustomerId = c.ExternalCustomerId,
                Age = c.Age,
                Gender = c.Gender,
                Country = c.Country,
                CreatedAtUtc = c.CreatedAtUtc
            })
            .ToListAsync();

        var customersCollectionDto = new CustomersCollectionDto
        {
            Data = customers
        };
        
        return Ok(customersCollectionDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDto>> GetCustomer(string id)
    {
        CustomerDto? customer = await dbContext
            .Customers
            .Where(c => c.Id == id)
            .Select(c => new CustomerDto
            {
                Id = c.Id,
                ExternalCustomerId = c.ExternalCustomerId,
                Age = c.Age,
                Gender = c.Gender,
                Country = c.Country,
                CreatedAtUtc = c.CreatedAtUtc
            })
            .FirstOrDefaultAsync();

        if (customer is null)
        {
            return NotFound();
        }

        return Ok(customer);
    }
}
