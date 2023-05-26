using System.Linq.Expressions;

namespace Core.BaseRepository
{
    public interface IGenericRepository<T> where T : class, new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> Where(Expression<Func<T, bool>> expression);
    }
}