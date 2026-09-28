using FINCORE_ERP_Application.Models;

namespace FINCORE_ERP_Application.Interfaces
{
    public interface IAuthenticationService
    {
        //Task SignUp(User us);
        Task<User?> SignIn(string Email, string Password);
        // Task<User> GetUserByEmail(string email);
        Task<User?> LoginWithGoogle(string email);

    }
}
