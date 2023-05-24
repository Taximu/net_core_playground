using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers;

public class AccountController : Controller
{
    public async Task<IActionResult> Login()
    {
        if(!HttpContext.User.Identity.IsAuthenticated)
        {
            await HttpContext.ChallengeAsync("Auth0", new AuthenticationProperties { RedirectUri = "/Home/Index" });
            //return Challenge(OpenIdConnectDefaults.AuthenticationScheme);
        }
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Logout()
    {
        return new SignOutResult(new[]
        {
            OpenIdConnectDefaults.AuthenticationScheme,
            CookieAuthenticationDefaults.AuthenticationScheme
        });
    }
}