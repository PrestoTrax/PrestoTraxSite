using PrestoTraxSite.Models.Responses;

namespace PrestoTraxSite.Models.API_Results
{
    public class RecordResultModel : SuccessResultModel
    {
        public int Code { get; set; }
        public List<RecordModel> QueryResult { get; set; }

        public RecordResultModel()
        {
            QueryResult = new List<RecordModel>();
        }
        public RecordResultModel(int code, List<RecordModel> queryResult)
        {
            Code = code;
            QueryResult = queryResult;
        }
        public RecordResultModel(int code)
        {
            Code = code;
            QueryResult = new List<RecordModel>();
        }
        
        public override string ToString() {
            string res = "";
            foreach (RecordModel r in QueryResult)
            {
                res += r.ToString() + "\n";
            }
            return res;
        }
    }
}
