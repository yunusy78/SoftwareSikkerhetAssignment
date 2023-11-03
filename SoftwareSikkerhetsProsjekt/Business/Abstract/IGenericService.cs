namespace Business.Abstract;

public interface IGenericService<T> where T : class, new()
{
    void Add(T entity);
    void Delete(T entity);
    void Update(T entity);
    List<T> GetAll();
    T GetById(int id);
}