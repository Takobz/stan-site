namespace STANWEBAPI.Exceptions
{
    public class ApplicationHttpException : Exception
    {
        public ApplicationHttpException(
            string message,
            string[] errors,
            int statusCode = 500) : base(message)
        {
            ErrorMessage = message;
            Errors = errors;
            StatusCode = statusCode;
        }

        public int StatusCode { get; }
        public string ErrorMessage { get; }
        public string[] Errors { get; }
    }
}