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
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById();
        Task<T> UpdateAsync(int Id);
        Task<bool> DeleteAsync(int Id);
    }
}
