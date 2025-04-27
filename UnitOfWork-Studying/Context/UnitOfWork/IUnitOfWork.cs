using UnitOfWork_Studying.Interfaces;

namespace UnitOfWork_Studying.Context.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : class;
        Task<int> CommitAsync();
    }
}
