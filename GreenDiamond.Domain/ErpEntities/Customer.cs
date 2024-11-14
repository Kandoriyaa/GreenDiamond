using System;
using System.Collections.Generic;

namespace GreenDiamond.Domain.ErpEntities;

public partial class Customer
{
    public int CustId { get; set; }

    public string? CustFirstName { get; set; }

    public string? CustLastName { get; set; }

    public string? CustUserName { get; set; }

    public string? CustPassword { get; set; }

    public string? CustEmailAddrerss { get; set; }

    public bool? CustApproved { get; set; }

    public int? CustPhoneNo { get; set; }

    public string? CustAddress { get; set; }

    public string? CustCountry { get; set; }

    public string? CustState { get; set; }

    public string? CustCity { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDelete { get; set; }
}
