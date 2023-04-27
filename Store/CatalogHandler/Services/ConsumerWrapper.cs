using Confluent.Kafka;

namespace CatalogHandler.Services;

public class ConsumerWrapper
{
    private readonly string _topicName;
    private readonly ConsumerConfig _consumerConfig;
    public ConsumerWrapper(ConsumerConfig config, string topicName)
    {
        _topicName = topicName;
        _consumerConfig = config;
    }
    
    public string ReadMessage()
    {
        using var consumer = new ConsumerBuilder<Ignore, string>(_consumerConfig).Build();
        consumer.Subscribe(_topicName);
        var cancelled = false;
        while (!cancelled)
        {
            try
            {
                var consumeResult = consumer.Consume();
                return consumeResult.Message.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cancelled = true;
                consumer.Close();
            }
        }

        return "Consumer Terminated";
    }
}
