using Infrastructure.DBContext;
using Infrastructure.Interface;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public OrderRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<ProcessResponse<bool>> ApplyOffer(AppliedOffer appliedOffer)
        {
            ProcessResponse<bool> processResponse = new ProcessResponse<bool>();
            try
            {
                var offer = await _dbContext.AppliedOffers.AddAsync(appliedOffer);
                //var test = _dbContext.Orders.Include(e=>e.Customer)
                //    .Include(e => e.)
                await _dbContext.SaveChangesAsync();
                if (offer != null)
                {
                    processResponse.Data = true;
                }
            }
            catch (Exception ex)
            {
                processResponse.Success = false;
                processResponse.Data = false;
            }
            return processResponse;
        }
    }
}
