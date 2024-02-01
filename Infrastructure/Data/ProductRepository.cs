using Core.Entities;
using Core.interfaces;

namespace Infrastructure.Data{
    public class ProductRepository : IProductRepository
    {
        public Task<Product> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Product>> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}