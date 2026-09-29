using FINCORE_ERP_Application.Models;

namespace FINCORE_ERP_Application.Interfaces
{
    public interface IPurchaseOrderService
    {
        Task AddPurchaseOrder(PurchaseOrder p);

        Task<List<PurchaseOrder>> GetAllPurchaseOrders();

        Task<PurchaseOrder> GetPurchaseOrderById(int id);

        Task UpdatePurchaseOrder(PurchaseOrder p);

        Task DeletePurchaseOrder(int id);
    }
}