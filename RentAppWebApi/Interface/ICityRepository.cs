using RentAppWebApi.Model;

namespace RentAppWebApi.Interface
{
    public interface ICityRepository : IGenericRepository<City>
    {
        IEnumerable<City> GetCitiesByCountry(int countryId);
    }
}
