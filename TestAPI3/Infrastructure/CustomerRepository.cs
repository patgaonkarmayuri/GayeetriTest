using Infrastructure.DBContext;
using Infrastructure.Interface;
using Infrastructure.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }

        public async Task<ProcessResponse<bool>> GetByName()
        {
            return null;
        }
    }
}
