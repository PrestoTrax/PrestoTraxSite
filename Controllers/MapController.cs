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
            List<RecordModel> userRecords = await GetRecordsAsync();
            //Console.WriteLine($"{location.Longitude}, {location.Latitude}");
            return View(userRecords);
        }
        [Route("/Map/GetRecordsAsync")]
        public async Task<List<RecordModel>> GetRecordsAsync()
        {
            List<RecordModel> userRecords = await _recordService.GetUserRecords(8);
            return userRecords;
        }

        public async Task<IActionResult> GetMapComponent()
        {
            List<RecordModel> userRecords = await _recordService.GetUserRecords(8);
            return PartialView("_MapComponent", userRecords);
        }

    }
}
