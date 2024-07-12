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
        Task<Post> CreateAsync(Post entity,string text);
    }
}
