using Microsoft.Extensions.Logging;

namespace Messagin.Kafka;

public class OrderCreatedMessageHandler(ILogger<OrderCreatedMessageHandler> logger) : IMessageHandler<OrderCreated>
{
    public Task HandleAsync(OrderCreated message, CancellationToken cancellationToken)
    {
        logger.LogInformation(message.Id);
        return Task.CompletedTask;
    }
}
