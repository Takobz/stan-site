namespace STANWEBAPI.Models.DTOs.Responses
{
    public class BaseResponse<TData> where TData : class
    {

        public BaseResponse(TData data)
        {
            Data = data;
            Errors = [];
        }

        public BaseResponse(string errorMessage, string[] errors)
        {
            Errors = errors;
            Data = default;
            ErrorMessage = errorMessage;
        }

        public TData? Data { get; }
        public string[] Errors { get; } = [];
        public string? ErrorMessage { get; }
    }

    public class EmptyData { }
}