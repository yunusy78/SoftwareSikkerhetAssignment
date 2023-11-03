using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
    }
    public DbSet<Blog> Blogs { get; set; }

    public DbSet<Contact> Contacts { get; set; }
    
}