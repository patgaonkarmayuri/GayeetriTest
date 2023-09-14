using Infrastructure.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IOrder : IBaseService<Order>
    {
        Task<ProcessResponse<Order>> Create(Order item, int offerId);
    }
}
