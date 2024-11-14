using System;
using System.Collections.Generic;

namespace GreenDiamond.Domain.ErpEntities;

public partial class Login
{
    public int? Id { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDelete { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
