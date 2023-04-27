using CatalogHandler.Models;
using Confluent.Kafka;
using Newtonsoft.Json;

namespace CatalogHandler.Services;

public class ProcessProductsService : BackgroundService
{
    private readonly ConsumerConfig _consumerConfig;
    private readonly ProducerConfig _producerConfig;
    
    public ProcessProductsService(ConsumerConfig consumerConfig, ProducerConfig producerConfig)
    {
        _producerConfig = producerConfig;
        _consumerConfig = consumerConfig;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Product Processing Service Started");
            
        while (!stoppingToken.IsCancellationRequested)
        {
            var consumerHelper = new ConsumerWrapper(_consumerConfig, "product-requests");
            var productRequest = consumerHelper.ReadMessage();
            
            var request = JsonConvert.DeserializeObject<ProductRequest>(productRequest);
            
            Console.WriteLine($"Info: OrderHandler => Processing the order for {request?.ProductName}");
            if (request == null) continue;
            request.Status = ProductStatus.COMPLETED;

            var producerWrapper = new ProducerWrapper(_producerConfig, "ready-to-ship");
            await producerWrapper.WriteMessage(JsonConvert.SerializeObject(request));
        }
    }
}
