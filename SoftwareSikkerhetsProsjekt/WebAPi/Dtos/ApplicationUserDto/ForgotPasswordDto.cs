

namespace WebAPi.DTOs.ApplicationUserDto;

public class ForgotPasswordDto
{
    public string Id { get; set; }
    public string Email { get; set; }

    public string PasswordHash { get; set; }

    
    public string ResetToken { get; set; }

    
    public DateTime? ResetTokenExpiry { get; set; }
}