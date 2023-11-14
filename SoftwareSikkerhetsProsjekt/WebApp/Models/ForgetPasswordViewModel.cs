using Microsoft.Build.Framework;

namespace WebUI.Models;

public class ForgetPasswordViewModel
{
    [Required()]
    public string Email { get; set; }
}