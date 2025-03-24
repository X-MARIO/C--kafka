using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Messagin.Kafka;

public static class Extensions
{
    public static IServiceCollection AddConsumer<TMessage, THandler>(this IServiceCollection serviceCollection,
        IConfigurationSection configurationSection) where THandler : class, IMessageHandler<TMessage>
    {
        serviceCollection.Configure<KafkaSettings>(configurationSection);
        serviceCollection.AddHostedService<KafkaConsumer<TMessage>>();
        serviceCollection.AddSingleton<IMessageHandler<TMessage>, THandler>();

        return serviceCollection;
    }
}
