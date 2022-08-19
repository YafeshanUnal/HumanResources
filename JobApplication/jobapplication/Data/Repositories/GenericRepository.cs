using System.Collections.Generic;
using System.Linq;
using jobapplication.Data.Database;
using Microsoft.EntityFrameworkCore;

namespace jobapplication.Data.Repositories
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }


        public List<T> GetListAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Insert(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

    }
}