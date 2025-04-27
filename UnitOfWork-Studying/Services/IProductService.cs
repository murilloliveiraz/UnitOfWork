using UnitOfWork_Studying.Domain;

namespace UnitOfWork_Studying.Services
{
    public interface IProductService
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductsAsync();
        Task AddProductAsync(Product entity);
        Task UpdateProductAsync(Product entity);
        Task DeleteProductAsync(int id);
    }
}
