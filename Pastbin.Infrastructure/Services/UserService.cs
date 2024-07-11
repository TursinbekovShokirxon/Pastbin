using Pastbin.Application.Interfaces;
using Pastbin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastbin.Infrastructure.Services
{
    public class UserService : IUserService
    {
        public Task<User> CreateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById()
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
