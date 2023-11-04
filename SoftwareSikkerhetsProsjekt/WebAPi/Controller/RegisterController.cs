using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;
using WebAPi.DTOs.ApplicationUserDto;
using WebAPi.Model;
using WebAPi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
      private readonly IApplicationUserService _applicationUserRepository;

      public RegisterController(IApplicationUserService applicationUserRepository)
      {
          _applicationUserRepository = applicationUserRepository;
      }


      [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(ApplicationViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Şifreyi hashle
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);
        
                // Kullanıcı bilgilerini ApplicationUserDto'dan çıkar
                var user = new AppUser()
                {
                    UserName = model.Email,
                    PasswordHash = passwordHash,
                    Email = model.Email
                };

                // Kullanıcı kaydı işlemi
                var userRegistered = await _applicationUserRepository.RegisterUser(user);

                if (userRegistered)
                {
                    return Ok("User registered successfully");
                }
                else
                {
                    return BadRequest("User registration failed");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    
    }
}