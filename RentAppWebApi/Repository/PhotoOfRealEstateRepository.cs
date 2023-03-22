using RentAppWebApi.Model;
using RentAppWebApi.Data;
using RentAppWebApi.Interface;

namespace RentAppWebApi.Repository
{
    public class PhotoOfRealEstateRepository : GenericRepository<PhotoOfRealEstate>, IPhotoOfRealEstateRepostitory
    {
        public PhotoOfRealEstateRepository(DataContext dataContext) : 
            base(dataContext, dataContext.PhotoOfRealEstates)
        {

        }

        public IEnumerable<PhotoOfRealEstate> GetPhotoOfRealEstatesByRealEstate(int realEstateId)
        {
            return _table.Where(x => x.RealEstateId == realEstateId).ToList();
        }
    }
}
