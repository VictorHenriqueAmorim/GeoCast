using GeoCast.Services.Models.Weather.Point;
using System.Text.Json.Serialization;

namespace GeoCast.Services.Models.Weather.Points
{
    public class GridPoint
    {
        [JsonPropertyName("properties")]
        public PointProperties Properties { get; set; }
    }
}
