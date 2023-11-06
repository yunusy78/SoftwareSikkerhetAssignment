using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class PasswordController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}