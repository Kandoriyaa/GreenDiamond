using System;
using System.Collections.Generic;

namespace GreenDiamond.Domain.ErpEntities;

public partial class Category
{
    public int Id { get; set; }

    public string? ClotheName { get; set; }

    public decimal? Price { get; set; }

    public string? Photo { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? CreateDate { get; set; }

    public bool? IsDelete { get; set; }

    public bool? IsActive { get; set; }

    public string? Discription { get; set; }

    public int? Quantity { get; set; }

    public string? TypeOfMaterial { get; set; }

    public string? Discount { get; set; }

    public string? Manufacturer { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
