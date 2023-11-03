using Business.Abstract;
using Business.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Container;

public static class ScopeService
{
     public static void ContainerDependencies(this IServiceCollection Services)

    {
        
        Services.AddScoped<IBlogService, BlogManager>();
        Services.AddScoped<IContactService, ContactManager>();


    }
}