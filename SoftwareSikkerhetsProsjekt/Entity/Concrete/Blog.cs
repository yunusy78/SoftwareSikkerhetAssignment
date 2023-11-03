using Microsoft.AspNetCore.Identity;

namespace Entity.Concrete;

public class Blog
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? ShortDescription { get; set; }
    public string? Description { get; set; }
    public string? ImagePath { get; set; }
    public DateTime PostedTime { get; set; }
    public IdentityUser? PostedBy { get; set; }
    public string? PostedById { get; set; }
    public bool Status { get; set; }
}