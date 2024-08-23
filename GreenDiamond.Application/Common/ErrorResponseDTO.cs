using System.Text.Json;

namespace GreenDiamond.Application.Common
{
    public class ErrorResponseDto
    {
        public bool success { get; set; }
        public int status { get; set; }
        public string? message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}