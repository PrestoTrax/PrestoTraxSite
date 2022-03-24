namespace PrestoTraxSite.Models.API_Results
{
    public class UserResultModel
    {
        public int Code { get; set; }
        public List<UserModel> QueryResult { get; set; }

        public UserResultModel()
        {
            QueryResult = new List<UserModel>();
        }

        public UserResultModel(int code, List<UserModel> queryResult)
        {
            Code = code;
            QueryResult = queryResult;
        }
    }
}
