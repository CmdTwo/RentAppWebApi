using RentAppWebApi.Model;

namespace RentAppWebApi.Interface
{
    public interface IRealEstateRepository : IGenericRepository<RealEstate>
    {
        IEnumerable<RealEstate> GetRealEstatesByCountry(int countryId);
        IEnumerable<RealEstate> GetRealEstatesByCity(int cityId);
        IEnumerable<RealEstate> GetRealEstatesByLandLord(int landLordId);
        RealEstate GetRealEstateByReviewableObject(int reviewableObjectId);
    }
}
