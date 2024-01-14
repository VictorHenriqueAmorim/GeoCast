using GeoCast.Services.Interfaces;
using GeoCast.Services.Models.Geocoding;
using GeoCast.Services.Models.Weather;
using GeoCast.Services.Models.Weather.Points;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text.Json;

namespace GeoCast.Services.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IGeocodingService _geocodingService;
        private readonly IConfiguration _configuration;

        public WeatherService(IGeocodingService geocodingService, HttpClient httpClient, IConfiguration configuration)
        {
            _geocodingService = geocodingService;
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("GeoCast");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/cap+xml"));
            _configuration = configuration;
        }

        public async Task<List<Weather>> GetWeather(string address)
        {
            var addresses = await HandleAddress(address);
            var points = await HandleGridPoints(addresses);
            return await HandleWeather(points);
        }

        #region Private methods
        private async Task<List<AddressMatch>> HandleAddress(string address)
        {
            return await _geocodingService.GeocodeAddressAsync(address);
        }
        private async Task<List<GridPoint>> HandleGridPoints(List<AddressMatch> addresses)
        {
            List<GridPoint> points = new List<GridPoint>();

            foreach(var address in addresses)
            {
                var coordinates = address.Coordinates;
                var gridpoint = await GetGridPoint(coordinates.Latitude, coordinates.Longitude);
                points.Add(gridpoint);
            }

            return points;
        }
        private async Task<List<Weather>> HandleWeather(List<GridPoint> points)
        {
            List<Weather> weather = new List<Weather>();

            foreach(var point in points)
            {

                var weatherForecast = await GetWeatherForecast(point.Properties.Forecast);
                weatherForecast.Location = $"{point.Properties.GridId} X:{point.Properties.GridX} Y:{point.Properties.GridY}";

                weather.Add(weatherForecast);
            }

            return weather;
        }

        private async Task<GridPoint> GetGridPoint(double latitude, double longitude)
        {
            string apiUrl = $"{_configuration["WeatherAPI"]}/points/{latitude},{longitude}";

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<GridPoint>(content);
            }
            else
            {
                throw new HttpRequestException($"Failed to retrieve data. Status code: {response.StatusCode}");
            }
        }
        private async Task<Weather> GetWeatherForecast(string forecast)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(forecast);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Weather>(content);
            }
            else
            {
                throw new HttpRequestException($"Failed to retrieve data. Status code: {response.StatusCode}");
            }
        }
        #endregion Private methods
    }
}
