using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Entity.Concrete;
using WebAPi.DTOs.ApplicationUserDto;
using WebAPi.Model;
using WebAPi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IApplicationUserService _applicationService;
        private readonly IConfiguration _configuration;

        public AuthController(IApplicationUserService applicationService, IConfiguration configuration)
        {
            _applicationService = applicationService;
            _configuration = configuration;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(ApplicationViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Kullanıcı kimlik doğrulama işlemi
                var user = await _applicationService.AuthenticateUser(model.Email!, model.Password);

                if (user != null)
                {
                    

                    // Kullanıcı doğrulandı, bir JWT token oluşturun
                    var token = CreateToken(user);

                    // JWT token'i kullanıcıya dönün
                    return Ok(new { token });
                }
                else
                {
                    return BadRequest("Username or password is incorrect");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        
        private string CreateToken(AppUser userViewModel)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userViewModel.Email)
            };
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );
            var tokenHandler = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenHandler;
        }
        
        // AuthController.cs (veya uygun bir controller)
        [HttpPost]
        [Route("api/Auth/logout")]
        public IActionResult Logout()
        {
            // Kullanıcıyı oturumdan çıkarın (örneğin, JWT çerezini silin veya geçersizleştirin)

            // Örneğin, JWT çerezini silme
            Response.Cookies.Delete("JwtToken");

            return Ok("Logout successful");
        }
        
        

    }
}
