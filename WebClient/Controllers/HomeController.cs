using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebClient.Models;

namespace WebClient.Controllers;

public class HomeController : Controller
{
    //[Authorize(Roles="Manager")]
    [Authorize(Roles="Buyer")]
    public async Task<IActionResult> Index()
    {
        var result = "Hello!";
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:5019/api/v1/categories"))
            {
                result = await response.Content.ReadAsStringAsync();
            }
        }
        return new OkObjectResult(result);
    }
    
    [Authorize(Roles="Buyer")]
    public async Task<IActionResult> Check()
    {
        var result = "Hello!";
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:5019/api/v1/categories"))
            {
                result = await response.Content.ReadAsStringAsync();
            }
        }
        return new OkObjectResult(result);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}