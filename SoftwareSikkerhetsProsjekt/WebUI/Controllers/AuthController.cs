using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class AuthController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}