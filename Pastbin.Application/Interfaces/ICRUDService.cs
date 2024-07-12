using Pastbin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastbin.Application.Interfaces
{
    public interface ICRUDService<T>
    {
        Task<T> CreateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int Id);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int Id);
    }
}
