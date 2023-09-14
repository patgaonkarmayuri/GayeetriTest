using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class AppliedOffer
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public int? OfferId { get; set; }

    public virtual Offer? Offer { get; set; }

    public virtual Order? Order { get; set; }
}
