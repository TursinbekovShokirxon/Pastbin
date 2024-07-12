using Pastbin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastbin.Application.Interfaces
{
    public interface IPostService:ICRUDService<Post>
    {
<<<<<<< HEAD
       public Task<Post> CreateAsync(Post entity,string text);
        public Task<IEnumerable<Post>> GetAllAsync();
        public Task<Post> GetByIdAsync(int id);
        public Task<Post> UpdateAsync(Post entity);
        public Task<bool> DeleteAsync(int id);
=======
        Task<Post> CreateAsync(Post entity,string text);
>>>>>>> 910ea9b5db315ad83f318eda10a2e2701bd1a94d
    }
}
