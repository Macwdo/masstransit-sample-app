using MassTransit;
using MessagingContracts;

namespace Customers.Consumer.Workers;

public class CustomerDeletedConsumer: IConsumer<CustomerDeleted>
{
    private readonly ILogger<CustomerDeleted> _logger;

    public CustomerDeletedConsumer(ILogger<CustomerDeleted> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<CustomerDeleted> context)
    {
        _logger.LogInformation($"Customer Deleted: {context.Message.Id}");
        return Task.CompletedTask;
    }
}