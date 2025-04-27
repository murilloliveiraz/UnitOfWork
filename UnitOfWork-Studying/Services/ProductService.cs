using UnitOfWork_Studying.Context.UnitOfWork;
using UnitOfWork_Studying.Domain;
using UnitOfWork_Studying.Interfaces;

namespace UnitOfWork_Studying.Services
{
    public class ProductService: IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Product> _repository;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.Repository<Product>();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var products = await _repository.GetAllAsync();
            return products.ToList();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            return product;
        }

        public async Task AddProductAsync(Product product)
        {
            await _repository.AddAsync(product);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product != null)
            {
                _repository.Delete(product);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task UpdateProductAsync(Product entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}
