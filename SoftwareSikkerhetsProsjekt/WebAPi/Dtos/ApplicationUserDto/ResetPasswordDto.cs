using System.ComponentModel.DataAnnotations;

namespace WebAPi.DTOs.ApplicationUserDto;

public class ResetPasswordDto
{
    [Microsoft.Build.Framework.Required]
    public string Email { get; set; }

    [Microsoft.Build.Framework.Required]
    public string ResetToken { get; set; }

    [Microsoft.Build.Framework.Required]
    [StringLength(100, ErrorMessage = "Minumum lengt is 6", MinimumLength = 6)]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; }
}