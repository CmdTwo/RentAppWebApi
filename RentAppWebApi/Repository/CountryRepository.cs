using RentAppWebApi.Model;
using RentAppWebApi.Data;
using RentAppWebApi.Interface;

namespace RentAppWebApi.Repository
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(DataContext dataContext) :
            base(dataContext, dataContext.Countries)
        {

        }

        public Country GetCountryByName(string name)
        {
            return _table.FirstOrDefault(x => x.Name.Equals(name));
        }
    }
}
