using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Offer
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public DateTime? ValidUpto { get; set; }

    public decimal? Offer1 { get; set; }

    public bool? Fixed { get; set; }

    public virtual ICollection<AppliedOffer> AppliedOffers { get; set; } = new List<AppliedOffer>();
}
