using Pastbin.Application.Interfaces;
using Pastbin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastbin.Infrastructure.Services
{
    public class CommentService : ICommentService
    {
        public Task<string> createAsync(Comment comment, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Comment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Comment> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> UpdateAsync(Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}
