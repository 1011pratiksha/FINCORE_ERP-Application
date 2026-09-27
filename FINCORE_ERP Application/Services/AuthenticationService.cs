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
      

        public async Task<User?> SignIn(string Email, string Password)
        {
            var data = await db.User
                .Include(x=> x.role_id)
                .SingleOrDefaultAsync(x => x.email == Email && x.pass == Password);

            return data;
            
        }
        public async Task<User?> LoginWithGoogle(string email)
        {
            return await db.User
                .Include(x => x.role_id)
                .FirstOrDefaultAsync(x => x.email == email);
        }




    }
}
