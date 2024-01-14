using System.Text.Json.Serialization;

namespace GeoCast.Services.Models.Weather
{
    public class ProbabilityOfPrecipitation
    {
        [JsonPropertyName("unitCode")]
        public string? UnitCode { get; set; }

        [JsonPropertyName("value")]
        public int? Value { get; set; }
    }
}
