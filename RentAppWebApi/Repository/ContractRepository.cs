using RentAppWebApi.Model;
using RentAppWebApi.Data;
using RentAppWebApi.Interface;

namespace RentAppWebApi.Repository
{
    public class ContractRepository : GenericRepository<Contract>, IContractRepository
    {
        public ContractRepository(DataContext dataContext) : 
            base(dataContext, dataContext.Contracts)
        {

        }

        public IEnumerable<Contract> GetContractsByLandLordId(int landLordId)
        {
            return _table.Where(x => x.LandLordId == landLordId).ToList();
        }

        public IEnumerable<Contract> GetContractsByRenterId(int renterId)
        {
            return _table.Where(x => x.RenterId == renterId).ToList();
        }

        public IEnumerable<Contract> GetContractsByStatus(bool isActual)
        {
            return _table.Where(x => x.IsActual == isActual).ToList();
        }
    }
}
