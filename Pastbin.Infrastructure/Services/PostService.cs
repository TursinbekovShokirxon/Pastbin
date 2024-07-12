using Pastbin.Application.Interfaces;
using Pastbin.Domain.Entities;
using Pastbin.Infrastructure.DataAccess;

namespace Pastbin.Infrastructure.Services
{
    public class PostService : IPostService
    {
        public PastbinDbContext _db;

        public PostService(PastbinDbContext db)
        {
            _db = db;
        }

        public Task<Post> CreateAsync(Post entity, string text)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Post>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Post> UpdateAsync(Post entity)
        {
            throw new NotImplementedException();
        }
    }
}
