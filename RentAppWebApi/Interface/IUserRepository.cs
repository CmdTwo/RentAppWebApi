using RentAppWebApi.Model;

namespace RentAppWebApi.Interface
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetUserByLogin(string login);
    }
}
