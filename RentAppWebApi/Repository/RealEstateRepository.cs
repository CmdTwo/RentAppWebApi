using RentAppWebApi.Model;
using RentAppWebApi.Data;
using RentAppWebApi.Interface;

namespace RentAppWebApi.Repository
{
    public class RealEstateRepository : GenericRepository<RealEstate>, IRealEstateRepository
    {
        public RealEstateRepository(DataContext dataContext) : 
            base(dataContext, dataContext.RealEstates)
        {

        }

        public IEnumerable<RealEstate> GetRealEstatesByCity(int cityId)
        {
            return _table.Where(x => x.CityId == cityId).ToList();
        }

        public IEnumerable<RealEstate> GetRealEstatesByCountry(int countryId)
        {
            return _table.Where(x => x.CountryId == countryId).ToList();
        }

        public IEnumerable<RealEstate> GetRealEstatesByLandLord(int landLordId)
        {
            return _table.Where(x => x.LandLordId == landLordId).ToList();
        }
    }
}
