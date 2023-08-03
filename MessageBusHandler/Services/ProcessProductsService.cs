using AutoMapper;
using CatalogHandler.Models;
using CatalogHandler.Services.Subscriber;
using Confluent.Kafka;
using Confluent.Kafka.Admin;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Store.Core.Services.CartingService;
using Item = Store.Core.Models.Item;

namespace CatalogHandler.Services;

public class ProcessProductsService : BackgroundService
{
    private readonly string _topicName;
    private readonly ISubscriberWrapper _subscriber;
    private readonly IServiceProvider _serviceProvider;
    private readonly IMapper _mapper;
    
    public ProcessProductsService(ISubscriberWrapper subscriber, IOptions<TopicOptions> options, IServiceProvider serviceProvider, IMapper mapper)
    {
        _topicName = options.Value.TopicName;
        _subscriber = subscriber;
        _serviceProvider = serviceProvider;
        _mapper = mapper;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await CreateTopic(_topicName);
        Console.WriteLine("Product Processing Service Started");
            
        while (!stoppingToken.IsCancellationRequested)
        {
            var message = _subscriber.ReadMessage();
            
            if (string.IsNullOrEmpty(message))
                continue;
            
            var productRequest = JsonConvert.DeserializeObject<ProductRequest>(message);
            using (var scope = _serviceProvider.CreateScope())
            {
                var cartingService = scope.ServiceProvider.GetRequiredService<ICartingService>();
                var item = new Item
                {
                    ExternalId = productRequest.Id,
                    Name = productRequest?.Name,
                    Image = productRequest?.Image,
                    Price = productRequest.Price
                };
                await cartingService.UpdateItemAsync(item);
            }
            Console.WriteLine($"Info: ProductHandler => Processing the product with {productRequest.Id}");
            if (productRequest != null) productRequest.Status = ProductStatus.Completed;
        }
    }
    
    private static async Task CreateTopic(string topicName)
    {
        //TODO Pass BootstrapServer via DI
        using var adminClient = new AdminClientBuilder(new AdminClientConfig { BootstrapServers = "localhost:9092"}).Build();
        try
        {
            await adminClient.CreateTopicsAsync(new[] { 
                new TopicSpecification { Name = topicName, ReplicationFactor = 1, NumPartitions = 1 } });
        }
        catch (CreateTopicsException e)
        {
            Console.WriteLine($"An error occured creating topic {e.Results[0].Topic}: {e.Results[0].Error.Reason}");
        }
    }
}
