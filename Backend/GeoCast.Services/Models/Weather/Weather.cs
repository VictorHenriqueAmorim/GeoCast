using System.Text.Json.Serialization;

namespace GeoCast.Services.Models.Weather
{
    public class Weather
    {
        public string? Location { get; set; }
        [JsonPropertyName("properties")]
        public WeatherProperties WeatherProperties { get; set; }
    }
}
