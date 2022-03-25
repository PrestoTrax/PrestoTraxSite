using Newtonsoft.Json;
using PrestoTraxSite.Models;
using PrestoTraxSite.Models.API_Results;
using System.Text;
using System.Net.Http;

namespace PrestoTraxSite.Services.Data
{
    public class UserDataService
    {
        readonly HttpClient _client = new();
        //public async Task<List<UserModel>> GetAllUsers()
        //{
        //    var response = await _client.GetAsync("https://prestoapi.azurewebsites.net/users");
        //    List<UserModel> users;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync();

        //        var res = JsonConvert.DeserializeObject<UserResultModel>(content);
        //        users = res.QueryResult;

        //    }
        //    else
        //    {
        //        throw new Exception("Could not get users");
        //    }
        //    return users;
        //}

        public async Task<UserModel> GetUser(int id)
        {
            var response = await _client.GetAsync($"https://prestoapi.azurewebsites.net/users/{id}");
            UserModel user;
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);

                var res = JsonConvert.DeserializeObject<UserResultModel>(content);

                user = res.QueryResult[0];
                //Console.WriteLine(res);
            }
            else
            {
                throw new Exception("Could not get user");
            }
            return user;
        }
        
        public async Task<ResultModel> AuthenticateUser(UserModel user)
        {
            dynamic person = new {
            password = user.Password,
            username = user.Username
            };
            string personData = JsonConvert.SerializeObject(person);
            var data = new StringContent(personData, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("https://prestoapi.azurewebsites.net/users/login", data);
            //Console.WriteLine(response);
            string content = await response.Content.ReadAsStringAsync();
            //Console.WriteLine(content);
            ResultModel result = JsonConvert.DeserializeObject<ResultModel>(content);

            return result;
        }

    }
}
