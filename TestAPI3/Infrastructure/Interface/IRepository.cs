using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();

        Task<ProcessResponse<T>> GetById(int id);

        Task<ProcessResponse<T>> Create(T entity);

        Task<ProcessResponse<T>> Update(T entity);

        bool Delete(T entity);
    }
}
