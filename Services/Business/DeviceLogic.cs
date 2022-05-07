using PrestoTraxSite.Models;
using PrestoTraxSite.Services.Data;

namespace PrestoTraxSite.Services.Business
{
    public class DeviceLogic
    {
        private readonly DeviceDataService _dao;
        public DeviceLogic()
        {
            _dao = new();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <todo>Add IsMoving property to RecordModel class</todo>
        /// <param name="model">The DeviceModel object to be updated</param>
        /// <returns>The updated deviceModel</returns>
        public async Task PopulateRecords(DeviceModel model)
        {
            model.Records ??= new List<RecordModel>();
            Console.WriteLine(model.DeviceId);
            foreach (RecordModel record in await _dao.GetDeviceRecords(model.DeviceId))
            {
                if (!model.Records.Contains(record))
                {
                    model.Records.Add(record);
                }
            }

            RecordModel recentRecord = model.Records[0] ??= new(-1, -1, -1, false, new LocationModel("invalid latitude found", "no longitude found"), DateTime.Now);
            model.Location = recentRecord.Location;
            model.Moving = CheckMoving(model);
            //model.IsMoving = recentRecord.IsMoving;

            //return model;
        }

        public async Task PopulateRecords(List<DeviceModel> models)
        {
            foreach (DeviceModel model in models)
            {
                await PopulateRecords(model);
            }
        }

        public bool CheckMoving(DeviceModel model)
        {
            Console.WriteLine(model.DeviceLatitude);
            Console.WriteLine(model.DeviceLongitude);
            double LocSum1 = double.Parse(model.DeviceLatitude) + double.Parse(model.DeviceLongitude);
            double LocSum2 = double.Parse(model.Records[0].DeviceLatitude) + double.Parse(model.Records[0].DeviceLongitude);
            if (Math.Abs(LocSum1 - LocSum2) > 0.0003)
            {
                return true;
            }
            else
            {
                return false;
            }

            _dao.UpdateDevice(model);
        }
    }
}
