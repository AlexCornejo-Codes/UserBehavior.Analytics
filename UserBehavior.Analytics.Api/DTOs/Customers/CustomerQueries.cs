using System.Linq.Expressions;
using UserBehavior.Analytics.Api.Entities;

namespace UserBehavior.Analytics.Api.DTOs.Customers;

internal static class CustomerQueries
{
    public static Expression<Func<Customer, CustomerDto>> ProjectToDto()
    {
        return c => new CustomerDto
        {
            Id = c.Id,
            Age = c.Age,
            Gender = c.Gender,
            Country = c.Country,
            CreatedAtUtc = c.CreatedAtUtc
        };
    }
}
