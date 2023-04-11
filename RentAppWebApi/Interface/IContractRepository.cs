using RentAppWebApi.Model;

namespace RentAppWebApi.Interface
{
    public interface IContractRepository : IGenericRepository<Contract>
    {
        IEnumerable<Contract> GetContractsByStatus(bool isActual);
    }
}
