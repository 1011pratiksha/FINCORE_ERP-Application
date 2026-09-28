using FINCORE_ERP_Application.Models;

namespace FINCORE_ERP_Application.Interfaces
{
    public interface IOpexRequestService
    {
        Task createOpexRequest(OpexRequest or);

        Task<List<OpexRequest>> fetchOpexRequests();

        Task EditOpexRequest(OpexRequest or);

    }
}
