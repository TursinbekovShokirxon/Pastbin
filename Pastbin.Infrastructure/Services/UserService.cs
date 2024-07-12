using Microsoft.EntityFrameworkCore;
using Pastbin.Application.Interfaces;
using Pastbin.Domain.Entities;
using Pastbin.Infrastructure.DataAccess;

namespace Pastbin.Infrastructure.Services
{
    public class UserService : IUserService
    {
        public readonly PastbinDbContext _pastbinDb;
        public UserService(PastbinDbContext pastbinDb)
        {
            _pastbinDb = pastbinDb;
        }
        public Task<User> CreateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetByUsername(string username)
        {
            User? User = await _pastbinDb.Users.Where(x => x.Username == username).FirstOrDefaultAsync();
            return User;
        }

        public Task<User> UpdateAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
