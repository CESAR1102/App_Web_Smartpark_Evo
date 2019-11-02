using System.Collections.Generic;

namespace Smartpark.Repository
{
    public interface ICrudRepository<T>
    {
        bool  Save(T entity);
        bool  Update(T entity);
        bool  Delete(int id);
        IEnumerable<T> GetAll();
        T Get(int id);
    }
}