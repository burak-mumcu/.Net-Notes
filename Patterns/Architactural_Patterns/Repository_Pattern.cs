using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Patterns.Architactural_Patterns
{
    public interface IRepository<T> where T : class
    {
        // Id'ye göre veriyi getir
        T GetById(int id);

        // Tüm veriyi getir
        IEnumerable<T> GetAll();

        // Koşula göre veriyi getir
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        // Yeni veri ekle
        void Add(T entity);

        // Veri güncelle
        void Update(T entity);

        // Veri sil
        void Remove(T entity);
    }
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
    class Repository_Pattern
    {

    }
}
