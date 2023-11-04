using DataAccess.Context;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAPi.DTOs.ApplicationUserDto;

namespace WebAPi.Services;

public class ApplicationServices : IApplicationUserService
{
    private readonly ApplicationDbContext _context;
    
    public ApplicationServices(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<AppUser>> GetAllUserAsync()
    {
        try
        {
            var users = await _context.AppUsers.ToListAsync();
            return users;
        }
        catch (Exception ex)
        {
            
            return null;
        }
    }
    
    public async Task<bool> RegisterUser(AppUser applicationUserDto)
    {
        
            _context.AppUsers.AddAsync(applicationUserDto);
            await _context.SaveChangesAsync();
            return true;
        
    }
    
    public async Task<AppUser> AuthenticateUser(string email, string password)
    {
        try
        {
            var user = await _context.AppUsers.FirstOrDefaultAsync(x => x.Email == email);
            if (user == null)
            {
                return null;
            }
            else
            {
                // Şifre doğrulama
                bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
                if (isValidPassword)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
        }
        catch (Exception ex)
        {
           
            return null;
        }
    }
    
    
    
    
    public async Task<AppUser> FindByEmail(string email)
    {
        try
        {
            var user = await _context.AppUsers.FirstOrDefaultAsync(x => x.Email == email);
            if (user == null)
            {
                return null;
            }
            else
            {
                return user;
            }
        }
        catch (Exception ex)
        {
            
            return null;
        }
    }
    
    
    public async Task<bool> UpdateUser(AppUser dto)
    {
        try
        {
            _context.AppUsers.Update(dto);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            
            return false;
        }
    }
    
    
    public async Task<ForgotPasswordDto> FindByEmailFromForgetPassword(string resetToken)
    {
        try
        {
            var user = await _context.Set<ForgotPasswordDto>().FirstOrDefaultAsync(x => x.ResetToken == resetToken);
            if (user == null)
            {
                return null;
            }
            else
            {
                return user;
            }
        }
        catch (Exception ex)
        {
            
            return null;
        }
    }
    
    
    public async Task<bool> CreateForgotPasswordRecord(ForgotPasswordDto dto)
    {
        try
        {
            _context.Set<ForgotPasswordDto>().Add(dto);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            
            return false;
        }
    }
    
    
    

    

    
    
}