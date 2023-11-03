using System.Diagnostics;
using Business.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBlogService _blogService;
    private readonly UserManager<IdentityUser> _userManager;
    

    public HomeController(ILogger<HomeController> logger , IBlogService blogService, UserManager<IdentityUser> userManager)
    {
        _logger = logger;
        _blogService = blogService;
        _userManager = userManager;
    }
   

    public IActionResult Index()
    {
        var model = _blogService.GetListWithUserAsync();
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}