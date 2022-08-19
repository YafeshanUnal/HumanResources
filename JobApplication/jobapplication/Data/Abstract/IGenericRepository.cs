using System.Collections.Generic;

namespace jobapplication.Data.Repositories
{

    public interface IGenericRepository<T> where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetListAll();
        T GetById(int id);
    }
}