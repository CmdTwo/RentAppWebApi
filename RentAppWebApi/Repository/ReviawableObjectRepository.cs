using RentAppWebApi.Model;
using RentAppWebApi.Data;
using RentAppWebApi.Interface;

namespace RentAppWebApi.Repository
{
    public class ReviawableObjectRepository : GenericRepository<ReviewableObject>, IReviewableObjectRepository
    {
        public ReviawableObjectRepository(DataContext dataContext) :
            base (dataContext, dataContext.ReviewableObjects)
        {

        }
    }
}
