﻿using Infrastructure.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IOfferService : IBaseService<Offer> 
    {
        Task<ProcessResponse<List<Offer>>> GetOffersThatExpireToday();
    }
}
