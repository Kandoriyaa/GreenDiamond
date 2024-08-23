using GreenDiamond.Application.Common;

namespace GreenDiamond.Application.DTOs.GreenDiamond
{
    public class ClassOfTradeDto: AuditableDto
    {
        public string TradeCode { get; set; } = null!;

        public string? TradeDesc { get; set; }

        public bool? IsActive { get; set; }
    }

    public class ClassOfTradeListDto
    {
        public int TotalRecords { get; set; }

        public List<ClassOfTradeDto>? classOfTradeDtoinfo { get; set; }
    }
}
