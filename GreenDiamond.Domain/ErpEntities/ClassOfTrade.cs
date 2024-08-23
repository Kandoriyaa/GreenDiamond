using System;
using System.Collections.Generic;

namespace GreenDiamond.Domain.ErpEntities;

public partial class ClassOfTrade
{
    public string TradeCode { get; set; } = null!;

    public string? TradeDesc { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy { get; set; }
}
