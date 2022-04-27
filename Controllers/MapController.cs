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
            List<RecordModel> userRecords = await _recordService.GetUserRecords((int)HttpContext.Session.GetInt32("UUID"));
            return userRecords;
        }

        public async Task<IActionResult> GetMapComponent()
        {
            List<RecordModel> userRecords = await GetRecordsAsync();
            //if (userRecords.Count == 0)
            //{
            //    throw new Exception("No records found");

            return PartialView("_MapComponent", userRecords);
        }

    }
}
