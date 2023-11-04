using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using WebAPi.DTOs.ApplicationUserDto;

namespace WebAPi.Services;

public interface IApplicationUserService
{
    Task<List<AppUser>> GetAllUserAsync();
    Task<bool> RegisterUser(AppUser applicationUserDto);
    Task<AppUser> AuthenticateUser(string userName, string password);
    
    Task<AppUser> FindByEmail(string email);
    
    Task<bool> UpdateUser(AppUser dto);
    Task<ForgotPasswordDto> FindByEmailFromForgetPassword(string email);
    
    Task<bool> CreateForgotPasswordRecord(ForgotPasswordDto dto);
    
}