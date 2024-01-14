using System.Text.Json.Serialization;

namespace GeoCast.Services.Models.Geocoding
{
    public class GeocodingResult
    {
        [JsonPropertyName("addressMatches")]
        public List<Coordinate> Coordinates { get; set; }
    }
}
