using Pastbin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastbin.Application.Interfaces
{
    public interface IUserService:ICRUDService<User>
    {
        public Task<User> GetByUsername(string username);
    }
}
