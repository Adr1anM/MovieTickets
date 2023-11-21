using OnlineShop.Models;

namespace OnlineShop.Data.Base
{
    public interface IGenericRepository<T> where T :class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
    }
}
