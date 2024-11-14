using GreenDiamond.Application.Common;
using Microsoft.AspNetCore.Http;

namespace GreenDiamond.Application.DTOs.GreenDiamond
{
    public class ClotheDisplayDto : AuditableDto
    {
        public int? Id { get; set; }

        public string? ClotheName { get; set; }

        public decimal? Price { get; set; }

        public IFormFile? ClotheFile { get; set; }

        public string? Photo { get; set; }

        public bool? IsActive { get; set; }

        public string? Discription { get; set; }

        public int? Quantity { get; set; }

        public string? TypeOfMaterial { get; set; }

        public string? Discount { get; set; }

        public string? Manufacturer { get; set; }
    }

    public class ClotheDisplayListDto
    {
        public int TotalRecords { get; set; }

        public List<ClotheDisplayDto>? clothedisplayDtoinfo { get; set; }
    }
}
