using RentAppWebApi.Model;

namespace RentAppWebApi.Interface
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        IEnumerable<Review> GetReviewsByUser(int userId);
    }
}
