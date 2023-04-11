using RentAppWebApi.Data;
using RentAppWebApi.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace RentAppWebApi.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IModel
    {
        protected DataContext _dataContext;
        protected DbSet<T> _table;

        public GenericRepository(DataContext dataContext, DbSet<T> table)
        {
            _dataContext = dataContext;
            _table = table;
        }

        public IQueryable<T> Query()
        {
            return _table.AsQueryable<T>().AsNoTracking();
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public IEnumerable<T> GetAllWithInclude(params Expression<Func<T, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<T> GetAllWithInclude(Func<T, bool> predicate,
            params Expression<Func<T, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        public T GetById(int id)
        {
            return _table.Find(id);
        }

        public T GetByIdWithInclude(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            return Include(includeProperties).FirstOrDefault(x => x.Id == id);
        }

        public void Insert(T obj)
        {
            _table.Add(obj);
        }        

        public void Update(T obj)
        {
            _table.Attach(obj);
            _dataContext.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            _table.Remove(GetById(id));            
        }

        public bool IsExist(int id)
        {
            return _table.Any(x => x.Id == id);
        }

        public void Save()
        {
            _dataContext.SaveChanges();
        }

        protected IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _table.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
