namespace FarmController.Core.Exceptions
{
    public class BaseException : Exception
    {
        public int StatusCode { get; set; }
        public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();

        public BaseException(string? message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public BaseException(string? message, int statusCode, IEnumerable<string> errors) : base(message)
        {
            StatusCode = statusCode;
            Errors = errors;
        }
    }
}
