namespace PrestoTraxSite.Models
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
        public string DeviceLatitude { get; set; }
        public string DeviceLongitude { get; set; }
        public bool Moving { get; set; }
        public DateTime CreatedAt { get; }
        public List<RecordModel>? Records { get; set; }

        /// <summary>
        /// Full-args constructor 
        /// </summary>
        /// <param name="deviceId">Device ID</param>
        /// <param name="ownerId">Owner's User ID</param>
        /// <param name="location">Device's location</param>
        /// <param name="isMoving">Whether or not the device is in motion</param>
        public DeviceModel(int Id, int ownerId, LocationModel location, DateTime createdAt, bool moving)
        {
            this.DeviceId = Id;
            this.OwnerId = ownerId;
            this.Location = location;
            this.Moving = moving;
            this.CreatedAt = createdAt;
        }
        public override string ToString()
        {
            return $"{DeviceId}, {OwnerId}, {Location}, {Moving} {CreatedAt}";
        }
    }
}
