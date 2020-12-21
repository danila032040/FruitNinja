using System.Collections.Generic;

public interface IRepository<T>
{
    void Add(T value);
    void Remove(T value);
    IEnumerable<T> GetAll();
}
