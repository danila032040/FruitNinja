using System.Collections.Generic;

namespace Scripts.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T value);
        void Remove(T value);
        IEnumerable<T> GetAll();
    }
}
