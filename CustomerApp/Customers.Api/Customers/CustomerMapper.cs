using MessagingContracts;

namespace Customer.Api.Customers;

public static class CustomerMapper {

    public static CustomerCreated MapToCreated(this Customer customer)
    {
        return new CustomerCreated(
            customer.Id,
            customer.Name,
            customer.Address,
            customer.IsActive,
            customer.CreatedAt
        );
    }

    public static CustomerUpdated MapToUpdated(this Customer customer)
    {
        return new CustomerUpdated(
            customer.Id,
            customer.Name,
            customer.Address,
            customer.IsActive,
            customer.CreatedAt
        );
    }

    public static CustomerDeleted MapToDeleted(this Customer customer)
    {
        return new CustomerDeleted(
            customer.Id,
            customer.Name,
            customer.Address,
            customer.IsActive,
            customer.CreatedAt
        );
    }

    public static CustomerActivated MapToActivated(this Customer customer)
    {
        return new CustomerActivated(
            customer.Id,
            customer.Name,
            customer.Address,
            customer.IsActive,
            customer.CreatedAt
        );
    }

}