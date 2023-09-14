using Infrastructure.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<ProcessResponse<bool>> GetByName();
    }
}
