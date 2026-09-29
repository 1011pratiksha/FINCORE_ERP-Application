using FINCORE_ERP_Application.Models;

namespace FINCORE_ERP_Application.Interfaces
{
    public interface IAuthenticationService
    {
        //Task SignUp(User us);
        Task<string> SignIn(string Email, string Password);
        // Task<User> GetUserByEmail(string email);
        Task<User?> LoginWithGoogle(string email);
        Task<User> GetUserByEmail(string email);

    }
}
