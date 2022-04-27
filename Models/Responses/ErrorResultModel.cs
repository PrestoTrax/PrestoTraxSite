namespace PrestoTraxSite.Models.Responses
{
    public class ErrorResultModel : ResultModel
    {
        public string ErrorType { get; set; }
        public string Message { get; set; }

        public ErrorResultModel(string errorType, string message)
        {
            ErrorType = errorType;
            Message = message;
        }

        public ErrorResultModel(int code, string errorType, string message, string? content = null) : base(code, content)
        {
            ErrorType = errorType;
            Message = message;
            Content = null;
        }

        public ErrorResultModel()
        {
            ErrorType = "Unknown Error";
            Message = "An unknown error has occurred.";
        }

        public ErrorResultModel(int code, string errorType, string message)
        {
            Code = code;
            ErrorType = errorType;
            Message = message;
        }
    }
}
