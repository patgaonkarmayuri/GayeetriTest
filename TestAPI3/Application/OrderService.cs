using Application.Interface;
using Infrastructure;
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
    public class OrderService : BaseService<Order>, IOrder
    {
        private readonly IOrderRepository _repository;
        private readonly ICustomerService _customerService;
        private readonly IOfferService _offerService;
        public OrderService(IOrderRepository repository, ICustomerService customerService, IOfferService offerService) : base(repository)
        {
            _repository = repository;
            _offerService = offerService;
            _customerService = customerService;
        }

        public async Task<ProcessResponse<Order>> Create(Order item, int offerId)
        {
            ProcessResponse<Order> processResponse = new ProcessResponse<Order>();

            //validate if user is valid
            var custmerResponse = await _customerService.GetById(item.CustomerId??0);

            if(custmerResponse != null && custmerResponse.Success && custmerResponse.Data != null)
            {
                var orderResponse = await _repository.Create(item);
                
                if (offerId > 0 && orderResponse.Success && orderResponse.Data != null)
                {
                    await ApplyOffer(offerId, orderResponse.Data);
                }
            }

            return processResponse;
        }

        private async Task<bool> ApplyOffer(int offerId, Order order)
        {
            var offer = _offerService.GetById(offerId);
            bool offerApplied = false;

            AppliedOffer appliedOffer = new AppliedOffer()
            {
                OfferId = offerId,
                OrderId = order.Id
            };
            var resp = await _repository.ApplyOffer(appliedOffer);

            if(resp != null && resp.Success)
            {
                offerApplied = true;
            }

            return offerApplied;
        }

    }
}
