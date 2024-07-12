using Pastbin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastbin.Application.Interfaces
{
    public interface ICommentService:ICRUDService<Comment>
    {
     // public Task<string> createAsync(Comment comment,int userId);
    }
}
