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
}
