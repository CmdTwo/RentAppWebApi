using System.Linq.Expressions;

namespace RentAppWebApi.Interface
{
    public interface IGenericRepository<T> where T: class
    {
        IQueryable<T> Query();

        T GetByIdWithInclude( int id,
            params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> GetAllWithInclude(
            params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> GetAllWithInclude(Func<T, bool> predicate,
            params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        bool IsExist(int id);
        void Save();
    }
}
