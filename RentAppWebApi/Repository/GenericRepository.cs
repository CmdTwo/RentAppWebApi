using RentAppWebApi.Data;
using RentAppWebApi.Interface;
using Microsoft.EntityFrameworkCore;

namespace RentAppWebApi.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DataContext _dataContext;
        protected DbSet<T> _table;

        public GenericRepository(DataContext dataContext, DbSet<T> table)
        {
            _dataContext = dataContext;
            _table = table;
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetById(int id)
        {
            return _table.Find(id);
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

        private bool IsExist(T obj)
        {
            return _table.Contains(obj);
        }

        public void Save()
        {
            _dataContext.SaveChanges();
        }
    }
}
