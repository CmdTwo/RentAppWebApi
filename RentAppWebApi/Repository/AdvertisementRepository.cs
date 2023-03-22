using RentAppWebApi.Model;
using RentAppWebApi.Data;
using RentAppWebApi.Interface;

namespace RentAppWebApi.Repository
{
    public class AdvertisementRepository : GenericRepository<Advertisement>, IAdvertisementRepository
    {
        public AdvertisementRepository(DataContext dataContext) : 
            base(dataContext, dataContext.Advertisements)
        {

        }

        public IEnumerable<Advertisement> GetAdvertisementsByLandLord(int landLordId)
        {
            return _table.Where(x => x.LandLordId == landLordId).ToList();
        }

        public IEnumerable<Advertisement> GetAdvertisementsByRealEstate(int realEstateId)
        {
            return _table.Where(x => x.RealEsteteId == realEstateId).ToList();
        }
    }
}
