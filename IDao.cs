namespace BaoHiem.DAO;

/// <summary>Giao diện CRUD chung cho mọi DAO.</summary>
public interface IDao<T> where T : class
{
    IEnumerable<T> GetAll();
    T? GetById(string id);
    bool Add(T item);
    bool Update(string id, T item);
    bool Delete(string id);
}
