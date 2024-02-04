using Core.Entities;

namespace Core.interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task<T> GetById (int Id);
        public Task<IReadOnlyList<T>> GetList();
    }
}