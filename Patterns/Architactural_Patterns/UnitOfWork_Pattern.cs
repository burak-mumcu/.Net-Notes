using Microsoft.EntityFrameworkCore;
using Patterns.Architactural_Patterns.Models;


namespace Patterns.Architactural_Patterns
{

    public interface IUnitOfWork : IDisposable {
        IRepository<User> Users { get; }

        // Ürün repository'si
        IRepository<Product> Products { get; }
        
        int Complete();
    }

    public class UnitOfWork_Pattern : IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Product> _productRepository;


        public UnitOfWork_Pattern(DbContext context)
        {
            _context = context;
        }

        public IRepository<User> Users => _userRepository ?? new GenericRepository<User>(_context);
        public IRepository<Product> Products => _productRepository ?? new GenericRepository<Product>(_context);


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
