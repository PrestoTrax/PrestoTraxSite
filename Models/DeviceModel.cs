﻿namespace PrestoTraxSite.Models
{
    /// <summary>
    /// The class that contains a device's information
    /// </summary>
    public class DeviceModel
    {
        //device properties
        public int DeviceId { get; set; }
        public int OwnerId { get; set; }
        public LocationModel Location { get; set; }
        public bool IsMoving { get; set; }
        List<RecordModel>? Records { get; set; }

        /// <summary>
        /// Full-args constructor 
        /// </summary>
        /// <param name="deviceId">Device ID</param>
        /// <param name="ownerId">Owner's User ID</param>
        /// <param name="isMoving">Whether or not the device is in motion</param>
        public DeviceModel(int deviceId, int ownerId, LocationModel location, bool isMoving)
        {
            this.DeviceId = deviceId;
            this.OwnerId = ownerId;
            this.Location = location;
            this.IsMoving = isMoving;
            this.Records = new List<RecordModel>();
            
        }
        
        /// <summary>
        /// Makes an API call that obtains all of a device's records
        /// </summary>
        public void PopulateDeviceRecords()
        {
            
        }

        public RecordModel GetRecentRecord()
        {
            PopulateDeviceRecords();
            return Records[0];
        }

        public void PopulateRecentLocation()
        { 
            //this.Location = GetRecentRecord().Location;
        }
    }
}