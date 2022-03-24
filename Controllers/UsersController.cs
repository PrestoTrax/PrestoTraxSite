using Microsoft.AspNetCore.Mvc;
using PrestoTraxSite.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PrestoTraxSite.Models.API_Results;
//using System.Text;

namespace PrestoTraxSite.Controllers
{
    
    //[ApiController]
    //[Route("api")]
    public class UsersController : ControllerBase
    {
        readonly HttpClient _client = new() { BaseAddress = new Uri("https://prestoapi.azurewebsites.net/") };

        [HttpGet("/")]
        public async Task<List<UserModel>> GetAllUsers()
        {
            var response = await _client.GetAsync("/users");
            List<UserModel> users;
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);

                var res = JsonConvert.DeserializeObject<UserResultModel>(content);
                users = res.QueryResult;
                Console.WriteLine(res);

            }
            else
            {
                throw new Exception("Could not get users");
            }
            return users;
        }

        [HttpGet("/{id}")]
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
    }
}
