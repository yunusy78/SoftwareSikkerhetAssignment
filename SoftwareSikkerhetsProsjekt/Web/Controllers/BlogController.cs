using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class BlogController : Controller
{
    private readonly IBlogService _blogService;
    private readonly UserManager<ApplicationUser> _userManager;
    
    public BlogController(IBlogService blogService, UserManager<ApplicationUser> userManager)
    {
        _blogService = blogService;
        _userManager = userManager;
    }
    
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Details()
    {
        return View();
    }
    
    public IActionResult Create()
    {
        var user = _userManager.GetUserId(User);
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(Blog blog, IFormFile file)
    {
        if (file != null)
        {
            var extension = Path.GetExtension(file.FileName);
            var newImageName = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageFile/Blog/" + newImageName);
            var stream = new FileStream(location, FileMode.Create);
            file.CopyToAsync(stream);
            blog.ImagePath =@"/ImageFile/Blog/"+ newImageName;
        }
        else
        {
            blog.ImagePath = "default.png";
        }
        var user = _userManager.GetUserId(User);
        blog.PostedById = user;
        blog.PostedTime = DateTime.Now;
        blog.Status = true;
        _blogService.Add(blog);
        return RedirectToAction("Index", "Home");
    }
    
    public IActionResult Edit()
    {
        return View();
    }
    
    
    [HttpPost]
    public IActionResult Edit(Blog blog)
    {
        return View();
    }
   
}