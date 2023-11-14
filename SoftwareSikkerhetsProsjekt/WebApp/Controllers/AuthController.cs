using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Caching.Distributed;
using WebUI.Models;

namespace WebUI.Controllers;

public class AuthController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IEmailSender _emailSender;
    private readonly IDistributedCache _cache;

    public AuthController(UserManager<IdentityUser> userManager, 
        SignInManager<IdentityUser> signInManager, IEmailSender emailSender, IDistributedCache cache)
    {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailSender = emailSender;
            _cache = cache;
            
    }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
    
        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel p)
        {
            IdentityUser appUser = new IdentityUser()
            {
                Email = p.Email,
                UserName = p.Username
            };
            if (p.Password == p.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, p.Password);
                
                if (result.Succeeded)
                {
                    
                    return RedirectToAction("SignIn");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignViewModel.UserSignInViewModel p)
        {
            if (ModelState.IsValid)
            {
                // Check for consecutive failed login attempts
                var cacheKey = $"{p.username}_login_attempts";
                var attempts = Convert.ToInt32(_cache.GetString(cacheKey) ?? "0");

                if (attempts >= 3)
                {
                    // Implement mandatory time-out (lockout) logic here
                    // Optionally, you may want to log this event for auditing purposes
                    return RedirectToAction("Lockout", "Auth");
                }

                var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true);

                if (result.Succeeded)
                {
                    // Reset login attempts upon successful login
                    _cache.Remove(cacheKey);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Increment login attempts
                    _cache.SetString(cacheKey, (attempts + 1).ToString());

                    return RedirectToAction("SignIn", "Auth");
                }
            }
            return View();
        }
    
        [HttpGet]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("SignIn");
        }
        
        
        
        public IActionResult Lockout()
        {
            return View();
        }
        
        
    }
    
    
    
   
    
    
