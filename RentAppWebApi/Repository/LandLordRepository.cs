using RentAppWebApi.Model;
using RentAppWebApi.Data;
using RentAppWebApi.Interface;

namespace RentAppWebApi.Repository
{
    public class LandLordRepository : GenericRepository<LandLord>, ILandLordRepository
    {
        public LandLordRepository(DataContext dataContext) :
            base(dataContext, dataContext.LandLords)
        {

        }

        public LandLord GetLandLordByReviewableObject(int reviewableObjectId)
        {
            return _table.FirstOrDefault(x => x.ReviewableObjectId == reviewableObjectId);
        }

        public LandLord GetLandLordByUser(int userId)
        {
            return _table.FirstOrDefault(x => x.UserId == userId);
        }
    }
}
