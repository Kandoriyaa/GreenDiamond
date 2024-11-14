using System;
using System.Collections.Generic;

namespace GreenDiamond.Domain.ErpEntities;

public partial class CartMaster
{
    public int Id { get; set; }

    public int? CategoryId { get; set; }

    public int? CustId { get; set; }

    public int? Quantity { get; set; }

    public bool? IsDelete { get; set; }

    public bool? IsClear { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
