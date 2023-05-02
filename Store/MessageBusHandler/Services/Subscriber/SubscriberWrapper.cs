using CatalogHandler.Models;
using Confluent.Kafka;
using Microsoft.Extensions.Options;

namespace CatalogHandler.Services.Subscriber;

public class SubscriberWrapper : ISubscriberWrapper
{
    private readonly string _topicName;
    private readonly ConsumerConfig _consumerConfig;    
    public SubscriberWrapper(ConsumerConfig config, IOptions<TopicOptions> topicOptions)
    {
        _topicName = topicOptions.Value.TopicName;
        _consumerConfig = config;
    }
    
    public string ReadMessage()
    {
        using var consumer = new ConsumerBuilder<Ignore, string>(_consumerConfig).Build();
        consumer.Subscribe(_topicName); 
        try
        {
            var received = false;
            var message = "";
            while (!received)
            {
                var consumeResult = consumer.Consume();
                if (consumeResult?.Message == null) continue;
                message = consumeResult.Message.Value;
                received = true;
            }
            return message;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return "Terminated";
        }
    }
}
