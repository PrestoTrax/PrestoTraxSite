namespace PrestoTraxSite.Models.Responses
{
    public abstract class ResultModel
    {
        public int Code { get; set; }
        public dynamic? Content { get; set; }

        public ResultModel()
        {
            Code = 500;
            Content = "Unexpected Response";
        }

        public ResultModel(int code, dynamic content)
        {
            Code = code;
            Content = content;
        }


    }
}
