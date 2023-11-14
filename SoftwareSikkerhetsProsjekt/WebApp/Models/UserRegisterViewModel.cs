using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class UserRegisterViewModel
    {
        [Microsoft.Build.Framework.Required()]
        public string Username { get; set; }

        [Microsoft.Build.Framework.Required()]
        public string Email { get; set; }

        [Microsoft.Build.Framework.Required()]
        public string Password { get; set; }

        [Microsoft.Build.Framework.Required()]
        [Compare("Password",ErrorMessage ="Passwords are not same")]
        public string ConfirmPassword { get; set; }
    }
}
    