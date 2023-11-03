using System.Diagnostics;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBlogService _blogService;
    
    

    public HomeController(ILogger<HomeController> logger, IBlogService blogService)
    {
        _logger = logger;
        _blogService = blogService;
    }

    public IActionResult Index()
    {
        var blog = _blogService.GetAll();
        return View(blog);
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