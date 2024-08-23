namespace GreenDiamond.Application.Common
{
    public class ValidationErrorDto
    {
        public Validation Required { get; set; }

        public ValidationErrorDto(string Message)
        {
            Required = new Validation(Message);
        }
    }

    public class Validation
    {
        public string ErrorMessage { get; set; }

        public Validation(string Message)
        {
            ErrorMessage = Message;
        }
    }
}