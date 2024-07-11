using Pastbin.Application.Interfaces;
using Pastbin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastbin.Infrastructure.Services
{
    public class PostService : IPostService
    {
        public Task<Post> CreateAsync(Post entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Post>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetById()
        {
            throw new NotImplementedException();
        }

        public Task<Post> UpdateAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
