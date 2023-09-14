using Application.Interface;
using Infrastructure.Interface;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IRepository<T> _repository;
        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }
        public async virtual Task<ProcessResponse<T>> Create(T item)
        {
            return await _repository.Create(item);
        }

        public Task<ProcessResponse<T>> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProcessResponse<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ProcessResponse<T>> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public Task<ProcessResponse<T>> Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
