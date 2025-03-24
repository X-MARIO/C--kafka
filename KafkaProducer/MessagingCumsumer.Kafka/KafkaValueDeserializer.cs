using System.Text.Json;
using Confluent.Kafka;

namespace Messagin.Kafka;

public class KafkaValueDeserializer<TMessage> : IDeserializer<TMessage>
{
    public TMessage Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
    {
        return JsonSerializer.Deserialize<TMessage>(data)!;
    }
}
