using CatalogHandler.Models;
using Confluent.Kafka;
using Microsoft.Extensions.Options;

namespace CatalogHandler.Services.Publisher;

/// <summary>
/// Wraps a Kafka producer
/// </summary>
public sealed class PublisherWrapper : IPublisherWrapper, IDisposable
{
    private readonly string _topicName;
    private readonly IProducer<Null, string> _producer;

    public PublisherWrapper(ProducerConfig config, IOptions<TopicOptions> options)
    {
        _topicName = options.Value.TopicName;
        _producer = new ProducerBuilder<Null, string>(config).Build();
    }

    public async Task WriteMessage(string message)
    {
        try
        {
            var deliveryResult = await _producer.ProduceAsync(_topicName, new Message<Null, string> { Value = message });
            Console.WriteLine($"Delivered '{deliveryResult.Value}' to '{deliveryResult.TopicPartitionOffset}'");
        }
        catch (ProduceException<Null, string> e)
        {
            Console.WriteLine($"Delivery failed: {e.Error.Reason}");
        }
    }

    public void Dispose()
    {
        try
        {
            _producer.Flush(TimeSpan.FromSeconds(10));
        }
        finally
        {
            _producer.Dispose();
        }
    }
}
