namespace Customer.Api.Customers;

public interface ICustomerService
{
    Task AddCustomer(Customer customer);
    Task<Customer?> GetCustomer(Guid id);
    Task<IEnumerable<Customer>> GetCustomers();
    Task UpdateCustomer(Customer customer);
    Task DeleteCustomer(Guid id);
    Task ActiveCustomer(Guid id);
}