using Application.Interface;
using Infrastructure.Models;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Application
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _repository;
        public CustomerService(ICustomerRepository repository) : base(repository) 
        {
            _repository = repository;
        }
        public async Task<ProcessResponse<Customer>> Insert(Customer customer)
        {
            return await _repository.Create(customer);
        }
    }
}
