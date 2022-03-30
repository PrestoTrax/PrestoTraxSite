namespace PrestoTraxSite.Models.API_Results
{
    public class ResultModel
    {
        public int Code { get; set; }
        public string? ErrorType { get; set; }
        public string Message { get; set; }

        public ResultModel()
        {
            Code = 500;
            Message = "Unknown Error";
        }

        public ResultModel(int code, string errorType, string message)
        {
            Code = code;
            ErrorType = errorType;
            Message = message;
        }

        public ResultModel(int code, string message)
        {
            Code = code;
            Message = message;
        }

    }
}
