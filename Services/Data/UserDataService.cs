using Newtonsoft.Json;
using PrestoTraxSite.Models;
using PrestoTraxSite.Models.Responses;
using System.Text;
using System.Net.Http;
using PrestoTraxSite.Models.API_Results;

namespace PrestoTraxSite.Services.Data
{
    public class UserDataService
    {
        readonly HttpClient _client = new() { BaseAddress = new Uri("https://prestoapi.azurewebsites.net")};
        //public async Task<List<UserModel>> GetAllUsers()
        //{
        //    var response = await _client.GetAsync("/users");
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
            var response = await _client.GetAsync($"/users/{id}");
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
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                ResultModel result = JsonConvert.DeserializeObject<ResultModel>(content);
                return result;
            }
            else
            {
                throw new Exception("Could not authenticate user");
            }
            //Console.WriteLine(response
        }
        public async Task<ResultModel> AuthenticateUser(string username, string password)
        {
            dynamic person = new
            {
                password = password,
                username = username
            };
            string personData = JsonConvert.SerializeObject(person);
            var data = new StringContent(personData, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("https://prestoapi.azurewebsites.net/users/login", data);
            string content = await response.Content.ReadAsStringAsync();
            
            if (response.IsSuccessStatusCode)
            {
                SuccessResultModel result = JsonConvert.DeserializeObject<UserResultModel>(content);
                return result;
            }
            else
            {
                ErrorResultModel result = JsonConvert.DeserializeObject<ErrorResultModel>(content);
                Console.WriteLine(result.ErrorType);
                return result;
            }
            //Console.WriteLine(response);
        }

        public async Task<ResultModel> RegisterUser(UserModel user)
        {
            dynamic person = new
            {
                email = user.Email,
                password = user.Password,
                username = user.Username
            };
            string personData = JsonConvert.SerializeObject(person);
            var data = new StringContent(personData, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("https://prestoapi.azurewebsites.net/users/new", data);
            string content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                ResultModel result = JsonConvert.DeserializeObject<UserResultModel>(content);
                return result;
            }
            else
            {
                ErrorResultModel result = JsonConvert.DeserializeObject<ErrorResultModel>(content);
                Console.WriteLine(result.ErrorType);
                return result;
            }
            //Console.WriteLine(response);
        }
        public async Task<ResultModel> RegisterUser(string email, string username, string password)
        {
            dynamic person = new
            {
                email = email,
                password = password,
                username = username
            };
            string personData = JsonConvert.SerializeObject(person);
            var data = new StringContent(personData, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("https://prestoapi.azurewebsites.net/users/new", data);
            string content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                ResultModel result = JsonConvert.DeserializeObject<UserResultModel>(content);
                return result;
            }
            else
            {
                ErrorResultModel result = JsonConvert.DeserializeObject<ErrorResultModel>(content);
                Console.WriteLine(result.ErrorType);
                return result;
            }
            //Console.WriteLine(response);
        }
    }
}
