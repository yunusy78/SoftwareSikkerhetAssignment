using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers;

public class ContactController : Controller
{
    private readonly IContactService _contactService;
    
    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }
        
    
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Index(Contact contact)
    {
        if (ModelState.IsValid)
        {
            _contactService.Add(contact);
        }
        
        return RedirectToAction("Index", "Home");
    }
}