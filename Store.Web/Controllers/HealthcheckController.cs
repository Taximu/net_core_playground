using Microsoft.AspNetCore.Mvc;

namespace Store.Web.Controllers;

[ApiController]
[Route("/healthcheck")]
public class HealthcheckController
{
    [HttpGet]
    public Task<string> Index()
    {
        return Task.FromResult("{Status: ONLINE}");
    }
}
