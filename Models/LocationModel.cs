namespace PrestoTraxSite.Models
{
    public class LocationModel
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public LocationModel(string latitude, string longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public void ValidateLocation()
        {
            if (string.IsNullOrEmpty(Latitude) || string.IsNullOrEmpty(Longitude))
            {
                throw new Exception("Invalid location");
            }
        }
    }
}
