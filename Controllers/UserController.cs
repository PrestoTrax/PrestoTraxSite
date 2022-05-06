using Microsoft.AspNetCore.Mvc;
using PrestoTraxSite.Models.API_Results;
using PrestoTraxSite.Models.Responses;
using PrestoTraxSite.Services.Data;

namespace PrestoTraxSite.Controllers
{
    public class UserController : Controller
    {
        private readonly UserDataService _dataService;
        public UserController()
        {
            _dataService = new();
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> Authenticate()
        {
            ResultModel result = await _dataService.AuthenticateUser(Request.Form["username"], Request.Form["password"]);
            if(result.GetType() == typeof(ErrorResultModel))
            {
                ViewData["username"] = Request.Form["username"];
                ViewData["password"] = Request.Form["password"];
                return View("Login", result);
            }
            else
            {
                HttpContext.Session.SetInt32("UUID", ((UserResultModel)result).Uuid);
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> RegisterUser()
        {
            if (Request.Form["password"] != Request.Form["confirmPassword"])
            {
                return View("Register", new ErrorResultModel("","Passwords do not match"));
            }
            ResultModel result = await _dataService.RegisterUser(Request.Form["email"], Request.Form["username"], Request.Form["password"]);
            if (result.GetType() == typeof(ErrorResultModel))
            {
                ViewData["email"] = Request.Form["email"];
                ViewData["username"] = Request.Form["username"];
                ViewData["password"] = Request.Form["password"];
                return View("Register", result);
            }
            else
            {
                HttpContext.Session.SetInt32("UUID", ((UserResultModel)result).Uuid);
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
