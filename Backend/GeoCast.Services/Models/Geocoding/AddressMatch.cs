using System.Text.Json.Serialization;

namespace GeoCast.Services.Models.Geocoding
{
    public class AddressMatch
    {
        [JsonPropertyName("coordinates")]
        public Coordinates Coordinates { get; set; }

        [JsonPropertyName("matchedAddress")]
        public string MatchedAddress { get; set; }
    }
}
