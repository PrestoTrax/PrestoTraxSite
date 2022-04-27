using PrestoTraxSite.Models.Responses;

namespace PrestoTraxSite.Models.API_Results
{
    public class UserResultModel : SuccessResultModel
    {
        public int Code { get; set; }
        public List<UserModel> QueryResult { get; set; }
        public int Uuid { get; set; }

        public UserResultModel()
        {
            QueryResult = new List<UserModel>();
        }

        public UserResultModel(int code, List<UserModel> queryResult, int Id)
        {
            Code = code;
            QueryResult = queryResult;
            Uuid = Id;
        }
    }
}
