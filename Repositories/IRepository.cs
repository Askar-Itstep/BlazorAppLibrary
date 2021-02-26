using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppLibrary.Repositories
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllWithInclude(params string[] args);
        bool Create(T item);
        T Find(int id);
        T Find(Func<T, bool> predicate);
        bool Remove(T item);
        bool Update(T item);
    }
}
