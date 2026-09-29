using FINCORE_ERP_Application.Models;

namespace FINCORE_ERP_Application.Interfaces
{
    public interface ICapexRequestService
    {
        Task AddCapexRequest(CapexRequest cr);

        Task<List<CapexRequest>> fetchCapexRequests();

        Task EditCapexRequest(CapexRequest cr);

        Task<CapexRequest?> GetCapexRequestAsync();
    }
}
