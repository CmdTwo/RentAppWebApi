using RentAppWebApi.Model;
using RentAppWebApi.Data;
using RentAppWebApi.Interface;

namespace RentAppWebApi.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DataContext dataContext)
            : base(dataContext, dataContext.Users)
        {

        }

        public User GetUserByLogin(string login)
        {
            return _table.FirstOrDefault(x => x.Login == login);
        }
    }
}
