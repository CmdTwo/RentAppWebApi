using RentAppWebApi.Model;
using RentAppWebApi.Data;
using RentAppWebApi.Interface;

namespace RentAppWebApi.Repository
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        public CityRepository(DataContext dataContext) : 
            base(dataContext, dataContext.Cities)
        {

        }       

        public IEnumerable<City> GetCitiesByCountry(int countryId)
        {
            return _table.Where(x => x.CountryId == countryId).ToList();
        }       
    }
}
