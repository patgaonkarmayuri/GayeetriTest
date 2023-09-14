using Application.Interface;
using Infrastructure.Interface;
using Infrastructure.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class OfferService : BaseService<Offer>, IOfferService
    {
        private readonly IOfferRepository _repository;

        public OfferService(IOfferRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<ProcessResponse<List<Offer>>> GetOffersThatExpireToday()
        {
            return await _repository.GetAllOfferesExpiringToday();
        }
    }
}
