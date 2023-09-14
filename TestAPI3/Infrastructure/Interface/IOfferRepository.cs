using Infrastructure.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IOfferRepository : IRepository<Offer>
    {
        Task<ProcessResponse<List<Offer>>> GetAllOfferesExpiringToday();
    }
}
