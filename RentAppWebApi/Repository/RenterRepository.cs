using RentAppWebApi.Model;
using RentAppWebApi.Data;
using RentAppWebApi.Interface;

namespace RentAppWebApi.Repository
{
    public class RenterRepository : GenericRepository<Renter>, IRenterRepository
    {
        public RenterRepository(DataContext dataContext) :
            base(dataContext, dataContext.Renters)
        {

        }

        public Renter GetRenterByReviewableObject(int reviewableObjectId)
        {
            return _table.FirstOrDefault(x => x.ReviewableObjectId == reviewableObjectId);
        }

        public Renter GetRenterByUser(int userId)
        {
            return _table.FirstOrDefault(x => x.UserId == userId);
        }
    }
}
