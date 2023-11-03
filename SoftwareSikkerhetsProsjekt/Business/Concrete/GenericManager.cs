using System.Linq.Expressions;
using Business.Abstract;
using DataAccess.Context;

namespace Business.Concrete;

public class GenericManager <T> : IGenericService<T> where T : class, new()
{
        private readonly ApplicationDbContext _context;
        
        public GenericManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
                _context.SaveChanges();
                
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
                _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
                _context.SaveChanges();
        }

        public List<T> GetAll()
        {
                return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
                return _context.Set<T>().Find(id)!;
        }
}