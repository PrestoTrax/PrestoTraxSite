using Newtonsoft.Json;
using PrestoTraxSite.Models;
using PrestoTraxSite.Models.API_Results;

namespace PrestoTraxSite.Services.Data
{
    public class RecordDataService
    {
        readonly HttpClient _client = new() { BaseAddress = new Uri("https://prestoapi.azurewebsites.net") };

        public async Task<List<RecordModel>> GetUserRecords(int id)
        {
            var response = _client.GetAsync($"/records/user/{id}").Result;
            List<RecordModel> records;
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<RecordResultModel>(content);
                //Console.WriteLine(res);
                records = res.QueryResult;
                return records;
            }
            return new List<RecordModel>();
        }
        
    }
}
