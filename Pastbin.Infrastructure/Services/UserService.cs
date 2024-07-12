using Microsoft.EntityFrameworkCore;
using Pastbin.Application.Interfaces;
using Pastbin.Domain.Entities;
using Pastbin.Infrastructure.DataAccess;

namespace Pastbin.Infrastructure.Services
{
    public class UserService : IUserService
    {
        public readonly PastbinDbContext _db;
        public UserService(PastbinDbContext pastbinDb)
        {
            _db = pastbinDb;
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

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _db.Users.ToListAsync();
        }
        public async Task<User> GetByIdAsync(int Id)
        {
            User? user =await _db.Users.FirstOrDefaultAsync(x=> x.Id == Id);
            if (user == null)
            {
                throw new Exception($"User with Id {Id} not found.");
            }
            return user;

        }
        public async Task<User> GetByUsername(string username)
        {
            User? User = await _db.Users.Where(x => x.Username == username).FirstOrDefaultAsync();
            if (User == null)
            {
                throw new Exception($"User: {username} not found.");
            }
            return User;
        }

        public async Task<User> UpdateAsync(User user){
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
