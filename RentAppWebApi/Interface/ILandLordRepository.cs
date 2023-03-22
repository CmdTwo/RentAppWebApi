using RentAppWebApi.Model;

namespace RentAppWebApi.Interface
{
    public interface ILandLordRepository : IGenericRepository<LandLord>
    {       
        LandLord GetLandLordByUser(int userId);
        LandLord GetLandLordByReviewableObject(int reviewableObjectId);
    }
}
