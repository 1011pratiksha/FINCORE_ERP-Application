using FINCORE_ERP_Application.Data;
using FINCORE_ERP_Application.Interfaces;
using FINCORE_ERP_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace FINCORE_ERP_Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext db;
        public CustomerService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task AddAsync(Customer customer)
        {
            await db.Customers.AddAsync(customer);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await db.Customers.FindAsync(id);
            db.Customers.Remove(data);
            await db.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            var data = await db.Customers
                .Include(c => c.User)
                .Include(c => c.Company)
                .ToListAsync();

            return data;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await db.Customers.FindAsync(id);
        }

        public async  Task UpdateAsync(Customer customer)
        {
            db.Customers.Update(customer);
            await db.SaveChangesAsync();
        }
    }
}
