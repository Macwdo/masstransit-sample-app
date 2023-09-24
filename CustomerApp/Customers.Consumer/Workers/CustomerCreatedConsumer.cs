using MassTransit;
using MessagingContracts;

namespace Customers.Consumer.Workers;

public class CustomerCreatedConsumer: IConsumer<CustomerCreated>
{
    private readonly ILogger<CustomerCreated> _logger;

    public CustomerCreatedConsumer(ILogger<CustomerCreated> logger)
    {
        _logger = logger;
    }
    public Task Consume(ConsumeContext<CustomerCreated> context)
    {
        _logger.LogInformation($"Customer created: {context.Message.Name}");
        return Task.CompletedTask;
    }
}