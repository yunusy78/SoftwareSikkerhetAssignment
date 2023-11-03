using Microsoft.AspNetCore.Identity;

namespace Entity.Concrete;

public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
}