namespace UserBehavior.Analytics.Api.DTOs.CustomerChurn;

internal static class CustomerChurnMappings
{
    public static CustomerChurnDto ToDto(this Entities.CustomerChurn customerChurn)
    {
        return new CustomerChurnDto
        {
            Id = customerChurn.Id,
            CustomerId = customerChurn.CustomerId,
            Churned = customerChurn.Churned
        };
    }
    
    public static Entities.CustomerChurn ToEntity(this CreateCustomerChurnDto dto)
    {
        return new Entities.CustomerChurn
        {
            Id = $"cc_{Guid.CreateVersion7()}",
            CustomerId = dto.CustomerId,
            Churned = dto.Churned
        };
    }
}
