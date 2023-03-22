using RentAppWebApi.Model;

namespace RentAppWebApi.Interface
{
    public interface IPhotoOfRealEstateRepostitory : IGenericRepository<PhotoOfRealEstate>
    {
        IEnumerable<PhotoOfRealEstate> GetPhotoOfRealEstatesByRealEstate(int realEstateId);
    }
}
