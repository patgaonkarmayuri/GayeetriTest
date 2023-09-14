using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IBaseService<T> where T : class
    {
        Task<ProcessResponse<T>> GetAll();

        Task<ProcessResponse<T>> GetById(int id);

        Task<ProcessResponse<T>> Create(T item);

        Task<ProcessResponse<T>> Update(T item);

        Task<ProcessResponse<T>> DeleteById(int id);
    }
}
