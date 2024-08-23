using System.Text.Json.Serialization;

namespace GreenDiamond.Application.Common
{
    public class AuditableDto
    {
        public int Id { get; set; }

        [JsonIgnore]
        public int? CompanyId { get; set; }

        [JsonIgnore]
        public int? TenantId { get; set; }

        [JsonIgnore]
        public DateTime CreatedDate { get; set; }

        [JsonIgnore]
        public int? CreatedBy { get; set; }

        [JsonIgnore]
        public DateTime? ModifiedDate { get; set; }

        [JsonIgnore]
        public int? ModifiedBy { get; set; }

        [JsonIgnore]
        public bool? IsDeleted { get; set; } = false;
    }
}