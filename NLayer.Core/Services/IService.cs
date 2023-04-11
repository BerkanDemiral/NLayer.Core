using System.Linq.Expressions;

namespace NLayer.Core.Services
{
    /// <summary>
    /// Burada da yapı neredeyse tamamen IGenericRepository ile aynıdır ama farklı dönüş metodlarının tanımları da yapılabilmektedir.
    /// Örneğin burada direkt veritabanına bir müdahalede bulunacağımız için update ve delete için de Async tanım yaparız. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IService<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);
    }
}
