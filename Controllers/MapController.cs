using Microsoft.AspNetCore.Mvc;
using PrestoTraxSite.Models;
using PrestoTraxSite.Services.Data;

namespace PrestoTraxSite.Controllers
{
    public class MapController : Controller
    {
        private readonly RecordDataService _recordService;

        public MapController()
        {
            _recordService = new();
        }
        
        //public IActionResult Index()
        //{
        //    return View();
        //}
        
        public async Task<IActionResult> Index()
        {
            List<RecordModel> userRecords = await _recordService.GetUserRecords(8);
            //Console.WriteLine($"{location.Longitude}, {location.Latitude}");
            return View("_MapComponent", userRecords);
        }
    }
}
