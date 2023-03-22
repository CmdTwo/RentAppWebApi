using RentAppWebApi.Model;

namespace RentAppWebApi.Interface
{
    public interface IAdvertisementRepository : IGenericRepository<Advertisement>
    {
        IEnumerable<Advertisement> GetAdvertisementsByLandLord(int landLordId);
        IEnumerable<Advertisement> GetAdvertisementsByRealEstate(int realEstateId);
    }
}
