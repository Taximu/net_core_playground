using CatalogHandler.Models;
using CatalogHandler.Services;
using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CatalogHandler.Controllers;

[Route("api/[controller]")]
public class CatalogHandlerController : ControllerBase
{
    private readonly ProducerConfig _config;

    public CatalogHandlerController(ProducerConfig config)
    {
        _config = config;
    }

    [HttpPost]
    public async Task<ActionResult> PostAsync([FromBody] ProductRequest value)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var serializedProduct = JsonConvert.SerializeObject(value);

        Console.WriteLine("========");
        Console.WriteLine($"Info: {nameof(CatalogHandlerController)} => Post => Received a new product update:");
        Console.WriteLine(serializedProduct);
        Console.WriteLine("=========");

        var producer = new ProducerWrapper(_config,"product-requests");
        await producer.WriteMessage(serializedProduct);

        return Created("TransactionId", "Your product is in progress");
    }
}
