using MassTransit;
using MessagingContracts;

namespace Customers.Consumer.Workers;

public class CustomerUpdatedConsumer: IConsumer<CustomerUpdated>
{
    private readonly ILogger<CustomerUpdated> _logger;

    public CustomerUpdatedConsumer(ILogger<CustomerUpdated> logger)
    {
        _logger = logger;
    }
    public Task Consume(ConsumeContext<CustomerUpdated> context)
    {
        _logger.LogInformation($"Customer Updated: {context.Message.Name}");
        return Task.CompletedTask;
    }
}