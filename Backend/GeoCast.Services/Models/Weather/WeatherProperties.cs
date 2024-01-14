using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GeoCast.Services.Models.Weather
{
    public class WeatherProperties
    {
        [JsonPropertyName("periods")]
        public List<WeatherPeriod>? WeatherPeriods { get; set; }
    }
}
