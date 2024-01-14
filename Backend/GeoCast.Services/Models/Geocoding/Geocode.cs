using System.Text.Json.Serialization;

namespace GeoCast.Services.Models.Geocoding
{
    public class Geocode
    {

        [JsonPropertyName("addressMatches")]
        public List<AddressMatch> AddressMatches { get; set; }
    }
}
