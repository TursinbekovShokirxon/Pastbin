using Pastbin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastbin.Application.Interfaces
{
    public interface IPostService
    {
       public Task<Post> CreateAsync(Post entity,string text);
        public Task<IEnumerable<Post>> GetAllFromUsernameAsync(string Username);
        public Task<IEnumerable<Post>> GetAllAsync();
        public Task<Post> GetByIdAsync(int id);
        public Task<Post> UpdateAsync(Post entity);
        public Task<bool> DeleteAsync(int id);

    }
}
