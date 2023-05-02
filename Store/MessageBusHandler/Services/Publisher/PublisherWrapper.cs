using CatalogHandler.Models;
using Confluent.Kafka;
using Microsoft.Extensions.Options;

namespace CatalogHandler.Services.Publisher;

public class PublisherWrapper : IPublisherWrapper
{
    private readonly string _topicName;
    private readonly ProducerConfig _config;

    public PublisherWrapper(ProducerConfig config, IOptions<TopicOptions> options)
    {
        _topicName = options.Value.TopicName;
        _config = config;
    }
    
    public async Task WriteMessage(string message)
    {
        using var producer = new ProducerBuilder<Null, string>(_config).Build();
        try
        {
            var dr = await producer.ProduceAsync(_topicName, new Message<Null, string> { Value = message });
            Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
        }
        catch (ProduceException<Null, string> e)
        {
            Console.WriteLine($"Delivery failed: {e.Error.Reason}");
        }
    }
}
