using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserBehavior.Analytics.Api.Database;
using UserBehavior.Analytics.Api.DTOs.Customers;
using UserBehavior.Analytics.Api.Entities;

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
            .Select(CustomerQueries.ProjectToDto())
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
            .Select(CustomerQueries.ProjectToDto())
            .FirstOrDefaultAsync();

        if (customer is null)
        {
            return NotFound();
        }

        return Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult<CustomerDto>> CreateCustomer(CreateCustomerDto createCustomerDto)
    {
        Customer customer = createCustomerDto.ToEntity();
        
        dbContext.Customers.Add(customer);
        await dbContext.SaveChangesAsync();

        CustomerDto customerDto = customer.ToDto();
        
        return CreatedAtAction(nameof(GetCustomer), new { id = customerDto.Id }, customerDto);
    }
}
