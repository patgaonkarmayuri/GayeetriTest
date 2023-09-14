using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateTime? OrderDate { get; set; }

    public int? CustomerId { get; set; }

    public decimal? Amount { get; set; }

    public virtual ICollection<AppliedOffer> AppliedOffers { get; set; } = new List<AppliedOffer>();

    public virtual Customer? Customer { get; set; }
}
