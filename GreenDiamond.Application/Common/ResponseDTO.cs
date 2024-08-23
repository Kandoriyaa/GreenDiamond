namespace GreenDiamond.Application.Common
{
    public class ResponseDto
    {
        internal ResponseDto(bool success, string message, dynamic? data, int statusCode)
        {
            Success = success;
            Message = message;
            Data = data;
            StatusCode = statusCode;
        }

        internal ResponseDto(bool success, string message, int statusCode)
        {
            Success = success;
            Message = message;
            StatusCode = statusCode;
        }

        public bool Success { get; set; }

        public string Message { get; set; }

        public dynamic? Data { get; set; }

        public int? StatusCode { get; set; }

        public static ResponseDto SuccessResponse(string message, dynamic? data, int statusCode)
        {
            return new ResponseDto(true, message, data, statusCode);
        }

        public static ResponseDto FailureResponse(string message, int statusCode)
        {
            return new ResponseDto(false, message, statusCode);
        }
    }
}