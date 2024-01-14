using System.Text.Json.Serialization;

namespace GeoCast.Services.Models.Geocoding
{
    public class Coordinates
    {
        [JsonPropertyName("x")]
        public double Longitude { get; set; }

        [JsonPropertyName("y")]
        public double Latitude { get; set; }
    }
}
