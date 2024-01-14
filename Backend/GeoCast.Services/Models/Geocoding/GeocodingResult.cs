using System.Text.Json.Serialization;

namespace GeoCast.Services.Models.Geocoding
{
    public class GeocodingResult
    {
        [JsonPropertyName("result")]
        public Geocode Geocode { get; set; }
    }
}