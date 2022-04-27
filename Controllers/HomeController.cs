using Microsoft.AspNetCore.Mvc;
using PrestoTraxSite.Models;
using PrestoTraxSite.Models.API_Results;
using PrestoTraxSite.Services.Data;
using System.Diagnostics;

namespace PrestoTraxSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly UserDataService _userService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _userService = new UserDataService();
        }

        //public async Task<IActionResult> Login()
        //{
        //    ResultModel result = await _userService.AuthenticateUser(new UserModel(-1, "Mackslemus1", null, "G00dP@ssw0rd"));
        //    if(result.Code < 400)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Error", "Home");
        //    }
            
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}