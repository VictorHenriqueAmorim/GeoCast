using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace GeoCast.Services.Models.Weather.Point
{
    public class PointProperties
    {
        [JsonPropertyName("gridId")]
        public string GridId { get; set; }

        [JsonPropertyName("gridX")]
        public int GridX { get; set; }

        [JsonPropertyName("gridY")]
        public int GridY { get; set; }

        [JsonPropertyName("forecast")]
        public string Forecast { get; set; }
    }
}
