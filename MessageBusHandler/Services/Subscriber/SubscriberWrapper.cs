using CatalogHandler.Models;
using Confluent.Kafka;
using Microsoft.Extensions.Options;

namespace CatalogHandler.Services.Subscriber;

/// <summary>
/// Wraps a Kafka consumer.
/// </summary>
public sealed class SubscriberWrapper : ISubscriberWrapper, IDisposable
{
    private readonly IConsumer<Ignore, string> _consumer;

    public SubscriberWrapper(ConsumerConfig config, IOptions<TopicOptions> topicOptions)
    {
        var topicName = topicOptions.Value.TopicName;
        _consumer = new ConsumerBuilder<Ignore, string>(config).Build();
        _consumer.Subscribe(topicName);
    }

    public string? ReadMessage(CancellationToken cancellationToken = default)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                var consumeResult = _consumer.Consume(TimeSpan.FromMilliseconds(500));
                if (consumeResult == null)
                    continue;
                if (consumeResult.IsPartitionEOF)
                    continue;
                if (consumeResult.Message?.Value != null)
                    return consumeResult.Message.Value;
            }
            catch (ConsumeException ex)
            {
                Console.WriteLine($"Kafka consume error: {ex.Error.Reason}");
                throw;
            }
        }

        return null;
    }

    public void Dispose()
    {
        try
        {
            _consumer.Close();
        }
        finally
        {
            _consumer.Dispose();
        }
    }
}
