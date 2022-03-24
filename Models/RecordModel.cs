namespace PrestoTraxSite.Models
{
    /// <summary>
    /// The class that contains information regarding a device's location and more
    /// </summary>
    public class RecordModel
    {
        public int RecordId { get; set; }
        public int DeviceId { get; set; }
        public int OwnerId { get; set; }
        public bool ReportedLost { get; set; }
        public LocationModel Location { get; set; }
        public DateTime CreatedAt { get; set; }

        public RecordModel(int recordId, int deviceId, int ownerId, bool reportedLost, LocationModel location, DateTime createdAt)
        {
            RecordId = recordId;
            DeviceId = deviceId;
            OwnerId = ownerId;
            ReportedLost = reportedLost;
            Location = location;
            CreatedAt = createdAt;
        }
    }
}
