using Core.Entities;
using Core.Specifications;

namespace Core.interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task<T> GetById (int Id);
        public Task<IReadOnlyList<T>> GetList();
        Task <T> GetEntityWithSpec (ISpecification<T> spec);
        Task <IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task <int> CountAsync (ISpecification<T> spec);
    }
}