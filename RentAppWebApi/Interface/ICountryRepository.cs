using RentAppWebApi.Model;

namespace RentAppWebApi.Interface
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Country GetCountryByName(string name);
    }
}
