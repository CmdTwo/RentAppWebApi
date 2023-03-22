using RentAppWebApi.Model;
using RentAppWebApi.Data;
using RentAppWebApi.Interface;

namespace RentAppWebApi.Repository
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(DataContext dataContext) :
            base(dataContext, dataContext.Reviews)
        {

        }

        public IEnumerable<Review> GetReviewsByUser(int userId)
        {
            return _table.Where(x => x.UserId == userId).ToList();
        }
    }
}
