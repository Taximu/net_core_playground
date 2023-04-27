using Confluent.Kafka;

namespace CatalogHandler.Services;

public class ProducerWrapper
{
    private readonly string _topicName;
    private readonly ProducerConfig _config;

    public ProducerWrapper(ProducerConfig config, string topicName)
    {
        _topicName = topicName;
        _config = config;
    }
    
    public async Task WriteMessage(string message)
    {
        using var producer = new ProducerBuilder<Null, string>(_config).Build();
        await producer.ProduceAsync(_topicName, new Message<Null, string> { Value = message });
    }
}
