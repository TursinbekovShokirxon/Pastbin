using Microsoft.EntityFrameworkCore;
using Pastbin.Application.Interfaces;
using Pastbin.Domain.Entities;
using Pastbin.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastbin.Infrastructure.Services
{
    public class UserService : IUserService
    {
        public PastbinDbContext _db;
        public UserService(PastbinDbContext pastbinDbContext)
        {
            _db = pastbinDbContext;
        }
        public async Task<User> CreateAsync(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            User? user = await _db.Users.FirstOrDefaultAsync(u => u.Id == Id);
            if (user == null)
            {
                return false;
            }
            _db.Remove(user);
            await _db.SaveChangesAsync();
            return true;
        }

<<<<<<< HEAD

        public async Task<IEnumerable<User>> GetAllAsync()
=======
        public Task<IEnumerable<User>> GetAllAsync()
>>>>>>> e217a2eb481cdce2fd05e67703387f60b39b7f03
        {
            return await _db.Users.ToListAsync();
        }

<<<<<<< HEAD
        public async Task<User> GetByIdAsync(int Id)
=======
        public Task<User> GetByIdAsync()
>>>>>>> e217a2eb481cdce2fd05e67703387f60b39b7f03
        {
            User? user =await _db.Users.FirstOrDefaultAsync(x=> x.Id == Id);
            if (user == null)
            {
                throw new Exception($"User with Id {Id} not found.");
            }
            return user;

        }

        public Task<User> GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<User> UpdateAsync(User user)
        {
            _db.Users.Update(user);
            int executeRows = await _db.SaveChangesAsync();
            if (executeRows > 0)
            {
                return user;
            }
            throw new Exception($"User with Id {user.Id} not updated.");
        }
    }
}
