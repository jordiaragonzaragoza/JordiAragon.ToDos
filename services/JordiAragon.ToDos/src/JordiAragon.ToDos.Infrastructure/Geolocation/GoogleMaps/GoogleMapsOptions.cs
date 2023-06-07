namespace JordiAragon.ToDos.Infrastructure.Geolocation.GoogleMaps
{
    public class GoogleMapsOptions
    {
        public const string Section = "GoogleMaps";

        public string BaseUrl { get; set; }

        public string ApiKey { get; set; }
    }
}