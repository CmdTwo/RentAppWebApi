using RentAppWebApi.Model;

namespace RentAppWebApi.Interface
{
    public interface IRenterRepository : IGenericRepository<Renter>
    {
        Renter GetRenterByUser(int userId);
        Renter GetRenterByReviewableObject(int reviewableObjectId);
    }
}
