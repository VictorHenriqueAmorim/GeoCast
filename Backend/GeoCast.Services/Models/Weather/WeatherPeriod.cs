﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GeoCast.Services.Models.Weather
{
    public class WeatherPeriod
    {
        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("startTime")]
        public DateTime StartTime { get; set; }

        [JsonPropertyName("endTime")]
        public DateTime EndTime { get; set; }

        [JsonPropertyName("isDaytime")]
        public bool IsDaytime { get; set; }

        [JsonPropertyName("temperature")]
        public int Temperature { get; set; }

        [JsonPropertyName("temperatureUnit")]
        public string? TemperatureUnit { get; set; }

        [JsonPropertyName("probabilityOfPrecipitation")]
        public ProbabilityOfPrecipitation? ProbabilityOfPrecipitation { get; set; }

        [JsonPropertyName("windSpeed")]
        public string? WindSpeed { get; set; }

        [JsonPropertyName("windDirection")]
        public string? WindDirection { get; set; }

        [JsonPropertyName("icon")]
        public string? Icon { get; set; }

        [JsonPropertyName("shortForecast")]
        public string? ShortForecast { get; set; }

        [JsonPropertyName("detailedForecast")]
        public string? DetailedForecast { get; set; }
    }
}
