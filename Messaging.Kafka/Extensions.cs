using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Messaging.Kafka;

public static class Extensions
{
    public static void AddProducer<TMessage>(this IServiceCollection serviceCollection,
        IConfigurationSection configurationSection)
    {
        serviceCollection.Configure<KafkaSettings>(configurationSection);
        serviceCollection.AddSingleton<IKafkaProducer<TMessage>, KafkaProducer<TMessage>>();
    }
}
