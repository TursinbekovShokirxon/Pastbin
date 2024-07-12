using Pastbin.Application.Interfaces;
using Pastbin.Domain.Entities;
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

        public Task<IEnumerable<Post>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetByIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Post> UpdateAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
