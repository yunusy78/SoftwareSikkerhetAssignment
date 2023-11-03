using Business.Abstract;
using DataAccess.Context;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete;

public class BlogManager : GenericManager<Blog>, IBlogService
{
    private readonly ApplicationDbContext _context;
    public BlogManager(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    
    public List<Blog> GetListWithUserAsync()
    {
        return _context.Blogs.Include(x => x.PostedBy).ToList();
    }
}