using FINCORE_ERP_Application.Data;
using FINCORE_ERP_Application.Interfaces;
using FINCORE_ERP_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace FINCORE_ERP_Application.Services
{
    public class AuthenticationService : IAuthenticationService
    { 
        ApplicationDbContext db;
        public AuthenticationService(ApplicationDbContext db)
        {
            this.db = db;
        }
      

        public async Task<string> SignIn(string Email, string Password)
        {
            var data = await db.User
                .Include(x=> x.role)
                .SingleOrDefaultAsync(x => x.email == Email && x.pass == Password);

            if (data != null && data.role != null)
            {
                if (data.role.role_name.Equals("Admin"))
                {
                    return "Admin";
                }
                if (data.role.role_name.Equals("Vendor"))
                {
                    return "Vendor";
                }

                
            }
            return null;

        }
        public async Task<User?> LoginWithGoogle(string email)
        {
            return await db.User
                .Include(x => x.role_id)
                .FirstOrDefaultAsync(x => x.email == email);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await db.User
                .Where(x => x.email.Equals(email))
                .SingleOrDefaultAsync();
        }



    }
}
