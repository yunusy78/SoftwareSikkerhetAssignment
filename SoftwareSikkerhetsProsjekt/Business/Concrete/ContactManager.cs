using Business.Abstract;
using DataAccess.Context;
using Entity.Concrete;
namespace Business.Concrete;

public class ContactManager : GenericManager<Contact>, IContactService
{
    public ContactManager(ApplicationDbContext context) : base(context)
    {
    }

}