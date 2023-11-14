using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class Auth2FController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}