using UnitOfWork_Studying.Interfaces;
using UnitOfWork_Studying.Repositories;

namespace UnitOfWork_Studying.Context.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if(_repositories.ContainsKey(typeof(T)))
                return (IGenericRepository<T>)_repositories[typeof(T)];

            var repo = new GenericRepository<T>(_context);
            _repositories.Add(typeof(T), repo);
            return repo;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
