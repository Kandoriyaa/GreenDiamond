using GreenDiamond.Application.Common;

namespace GreenDiamond.Application.DTOs.GreenDiamond
{
    public class CustomerDto : AuditableDto
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

        public bool? IsActive { get; set; }

    }

    public class CustomerListDto
    {
        public int TotalRecords { get; set; }

        public List<CustomerDto>? CustomerDtoinfo { get; set; }
    }
}
