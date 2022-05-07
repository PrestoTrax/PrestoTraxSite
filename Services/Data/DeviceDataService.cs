using PrestoTraxSite.Models;
using Newtonsoft.Json;
using PrestoTraxSite.Models.API_Results;
using System.Text;

namespace PrestoTraxSite.Services.Data
{
    public class DeviceDataService
    {
        private readonly HttpClient _client = new() { BaseAddress = new Uri("https://prestoapi.azurewebsites.net") };
        public async Task<List<RecordModel>> GetDeviceRecords(int id)
        {
            var response = _client.GetAsync($"/records/device/{id}").Result;
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

        public async void UpdateDevice(DeviceModel device)
        {
            var response = _client.PutAsync($"/devices/{device.DeviceId}", new StringContent(JsonConvert.SerializeObject(device), Encoding.UTF8, "application/json")).Result;
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<DeviceResultModel>(content);
                Console.WriteLine(res);
            }
            
        }

        public async Task<List<DeviceModel>> GetUserDeviceInfo(int id)
        {
            var response = _client.GetAsync($"/devices/user/{id}").Result;
            List<DeviceModel> devices;
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<DeviceResultModel>(content);
                //Console.WriteLine(res);
                devices = res.QueryResult;
                return devices;
            }
            return new List<DeviceModel>();
        }
    }
}
