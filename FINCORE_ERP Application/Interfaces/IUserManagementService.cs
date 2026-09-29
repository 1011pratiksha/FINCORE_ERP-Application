using FINCORE_ERP_Application.Models;

namespace FINCORE_ERP_Application.Interfaces
{
    public interface IUserManagementService
    {
        Task<User> AddUser(User user);
        Task<User> EditUser(User user);
        Task<int> DelUser(int id);
        Task<List<User>> GetAllUsers();

        Task<Role> AddRole(Role role);
        Task<Role> EditRole(Role role);
        Task<int> DelRole(int id);
        Task<List<Role>> GetAllRoles();


    }
}
