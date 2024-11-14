using GreenDiamond.Application.Common;

namespace GreenDiamond.Application.DTOs.GreenDiamond
{
    public class LoginDto : AuditableDto
    {
        public int? Id { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

    }

    public class LoginListDto
    {
        public int TotalRecords { get; set; }

        public List<LoginDto>? loginDtoinfo { get; set; }
    }
}
