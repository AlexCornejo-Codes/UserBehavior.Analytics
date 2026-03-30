using UserBehavior.Analytics.Api.Entities;

namespace UserBehavior.Analytics.Api.DTOs.Customers;

internal static class CustomerMappings
{

    public static CustomerDto ToDto(this Customer customer)
    {
        return new CustomerDto
        {
            Id = customer.Id,
            ExternalCustomerId = customer.ExternalCustomerId,
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
            ExternalCustomerId = dto.ExternalCustomerId,
            Age = dto.Age,
            Gender = dto.Gender,
            Country = dto.Country,
            CreatedAtUtc = DateTime.UtcNow
        };
        
        return customer;
    }
}
