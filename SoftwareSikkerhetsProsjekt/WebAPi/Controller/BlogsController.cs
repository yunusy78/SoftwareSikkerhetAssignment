using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Business.Abstract;
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
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var blogs = _blogService.GetAll();
            return Ok(blogs);
        }
        

    }
}
