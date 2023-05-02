using Confluent.Kafka;

namespace CatalogHandler.Services.Subscriber;

public interface ISubscriberWrapper
{
    string ReadMessage();
}
