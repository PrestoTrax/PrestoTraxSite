namespace PrestoTraxSite.Models.API_Results
{
    public class DeviceResultModel
    {
        public int Code { get; set; }
        public List<DeviceModel> QueryResult { get; set; }

        public DeviceResultModel()
        {
            QueryResult = new List<DeviceModel>();
        }
        public DeviceResultModel(int code, List<DeviceModel> queryResult)
        {
            Code = code;
            QueryResult = queryResult;
        }
        public DeviceResultModel(int code)
        {
            Code = code;
            QueryResult = new List<DeviceModel>();
        }

        public override string ToString()
        {
            string res = "";
            foreach (DeviceModel device in QueryResult)
            {
                res += device.ToString() + "\n";
            }
            return res;
        }
    }
}
