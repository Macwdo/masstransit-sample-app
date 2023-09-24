using Customer.Api.Data;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Customer.Api.Customers;

public class CustomerService: ICustomerService
{
    private readonly AppDbContext _context;
    // You should be use IBus when your service is Singletons
    // if your service is Scoped you should be use IPublishEndpoint

    private readonly IPublishEndpoint _bus;

    public CustomerService(AppDbContext context, IPublishEndpoint bus)
    {
        _context = context;
        _bus = bus;
    }

    public async Task AddCustomer(Customer customer)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            await _context.Customers.AddAsync(customer);
            await SaveChangesAsync();

            var message = customer.MapToCreated();
            await _bus.Publish(message);

            await transaction.CommitAsync();
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<Customer?> GetCustomer(Guid id)
    {
        return await _context.Customers.FirstOrDefaultAsync(x => x!.Id == id);
    }

    public async Task<IEnumerable<Customer>> GetCustomers()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task UpdateCustomer(Customer customer)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            _context.Customers.Update(customer);
            await SaveChangesAsync();

            var message = customer.MapToUpdated();
            await _bus.Publish(message);

            await transaction.CommitAsync();
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw;
        }

    }

    public async Task DeleteCustomer(Guid id)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var customer = await GetCustomer(id);
            if (customer is null) throw new NullReferenceException();
            _context.Customers.Remove(customer);
            await SaveChangesAsync();

            var message = customer.MapToDeleted();
            await _bus.Publish(message);

            await transaction.CommitAsync();
        } catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw;
        }

    }

    public async Task ActiveCustomer(Guid id)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var customer = await GetCustomer(id);
            if (customer is null) throw new Exception("Customer not found");
            customer.IsActive = true;
            await SaveChangesAsync();

            var message = customer.MapToActivated();
            await _bus.Publish(message);

            await transaction.CommitAsync();
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    private Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}