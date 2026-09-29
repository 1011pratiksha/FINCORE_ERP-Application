using FINCORE_ERP_Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace FINCORE_ERP_Application.Services;

using FINCORE_ERP_Application.Data;
using FINCORE_ERP_Application.Models;
using Microsoft.EntityFrameworkCore;

public class UserManagementService : IUserManagementService
    {
    private readonly ApplicationDbContext db;
    public UserManagementService(ApplicationDbContext db)
    {
        this.db = db;
    }
        public async Task<User> AddUser(User user)
        {
        user.created_at = DateTime.Now;
        db.User.AddAsync(user);
        await db.SaveChangesAsync();
        return user;
        }

        public async Task<User> EditUser(User user)
        {
        var ExistingUser = await db.User.FindAsync(user.user_id);
        if (ExistingUser != null)
        {
            ExistingUser.modified_at = DateTime.Now;
            ExistingUser.modified_by = 1;
            db.Entry(ExistingUser).CurrentValues.SetValues(user);
            await db.SaveChangesAsync();
        }
        return ExistingUser;
        }

    public async Task<int> DelUser(int id)
        {
            var user = db.User.FirstOrDefault(x => x.user_id == id);
        if (user != null)
        {
            db.User.Remove(user);
            await db.SaveChangesAsync();
        }
        return user != null ? user.user_id : 0; 
        }

        public Task<List<User>> GetAllUsers()
        {
        return db.User.ToListAsync();
    }

        public async Task<Role> AddRole(Role role)
        {
        role.created_at = DateTime.Now;
         db.Role.AddAsync(role);
        await db.SaveChangesAsync();
        return role;
        }

        public async Task<Role> EditRole(Role role)
        {
        var ExistingRole = await db.Role.FindAsync(role.role_id);
        if(ExistingRole != null)
        {
            db.Entry(ExistingRole).CurrentValues.SetValues(role);

            ExistingRole.modified_at = DateTime.Now;
            ExistingRole.modified_by = 1;
            await db.SaveChangesAsync();
        }
        return ExistingRole;
    }

    public async Task<int> DelRole(int id)
        {
        var role = db.Role.FirstOrDefault(x => x.role_id == id);
        if (role != null)
        {
            db.Role.Remove(role);
            await db.SaveChangesAsync();
        }
        return role != null ? role.role_id : 0;
    }

        public Task<List<Role>> GetAllRoles()
        {
        return db.Role.ToListAsync();
        }
    }


    
