using UserBehavior.Analytics.Api.Entities;

namespace UserBehavior.Analytics.Api.DTOs.Customers;

internal static class CustomerMappings
{

    public static CustomerDto ToDto(this Customer customer)
    {
        return new CustomerDto
        {
            Id = customer.Id,
            Age = customer.Age,
            Gender = customer.Gender,
            Country = customer.Country,
            CreatedAtUtc = customer.CreatedAtUtc
        };
    }
    
    public static Customer ToEntity(this CreateCustomerDto dto)
    {
        Customer customer = new()
        {
            Id = $"c_{Guid.CreateVersion7()}",
            Age = dto.Age,
            Gender = dto.Gender,
            Country = dto.Country,
            CreatedAtUtc = DateTime.UtcNow
        };
        
        return customer;
    }
    
    public static void UpdateFromDto(this Customer customer, UpdateCustomerDto dto)
    {
        customer.Age = dto.Age;
        customer.Gender = dto.Gender;
        customer.Country = dto.Country;
    }
}
