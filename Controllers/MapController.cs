using Microsoft.AspNetCore.Mvc;
using PrestoTraxSite.Models;
using PrestoTraxSite.Services.Business;
using PrestoTraxSite.Services.Data;

namespace PrestoTraxSite.Controllers
{
    public class MapController : Controller
    {
        private readonly RecordDataService _recordService;
        private readonly DeviceDataService _deviceService;
        private readonly DeviceLogic _deviceLogic;
        public MapController()
        {
            _recordService = new();
            _deviceLogic = new();
            _deviceService = new();
        }
        
        //public IActionResult Index()
        //{
        //    return View();
        //}
        
        public async Task<IActionResult> Index()
        {
            List<DeviceModel> userDevices = await GetDevicesAsync();
            //Console.WriteLine($"{location.Longitude}, {location.Latitude}");
            return View(userDevices);
        }
        
        [HttpGet]
        [Route("/Map/GetDevicesAsync")]
        public async Task<List<DeviceModel>> GetDevicesAsync()
        {
            List<DeviceModel> userDevices = await _deviceService.GetUserDeviceInfo((int)HttpContext.Session.GetInt32("UUID"));
            foreach(DeviceModel userDevice in userDevices)
            {
                Console.WriteLine(userDevice.DeviceId);
            }
            await _deviceLogic.PopulateRecords(userDevices);
            return userDevices;
        }

        public async Task<IActionResult> GetMapComponent()
        {
            List<DeviceModel> userDevices = await GetDevicesAsync();
            //if (userRecords.Count == 0)
            //{
            //    throw new Exception("No records found");

            return PartialView("_MapComponent", userDevices);
        }

    }
}
