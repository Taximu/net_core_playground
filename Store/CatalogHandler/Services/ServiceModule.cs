using Confluent.Kafka;

namespace CatalogHandler.Services;

public static class ServicesModule
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IHostedService, ProcessProductsService>();
        var producerConfig = new ProducerConfig();
        var consumerConfig = new ConsumerConfig();
        configuration.Bind("producer", producerConfig);
        configuration.Bind("consumer", consumerConfig);
        services.AddSingleton(producerConfig);
        services.AddSingleton(consumerConfig);
    }
}
