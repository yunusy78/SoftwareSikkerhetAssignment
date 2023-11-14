using Microsoft.Build.Framework;

namespace WebUI.Models;

public class UserSignViewModel
{
    public class UserSignInViewModel
    {
        [Required()]
        public string username { get; set; }

        [Required()]
        public string password { get; set; }
    }
    
}