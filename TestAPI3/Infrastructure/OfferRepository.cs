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
    public class OfferRepository : Repository<Offer>, IOfferRepository
    {
        private readonly ApplicationDBContext _dbContext;
        //private readonly DbSet<T> _entity;

        public OfferRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<ProcessResponse<List<Offer>>> GetAllOfferesExpiringToday()
        {
            ProcessResponse<List<Offer>> processResponse = new ProcessResponse<List<Offer>>();
            DateTime now = DateTime.Now;
            var expiredOffers = await _dbContext.Offers.Where(x=>x.ValidUpto < DateTime.Now).ToListAsync();
            processResponse.Data = expiredOffers;
            return processResponse;
        }
    }
}
