using GeoCast.Services.Interfaces;
using GeoCast.Services.Models.Geocoding;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace GeoCast.Services.Services
{
    public class GeocodingService : IGeocodingService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public GeocodingService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<List<AddressMatch>?> GeocodeAddressAsync(string address)
        {
            string url = $"{_configuration["GeocodingAPI"]}/onelineaddress?address={Uri.EscapeDataString(address)}&benchmark=2020&format=json";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string jsonResponse = await response.Content.ReadAsStringAsync();
            var geocodingResult = JsonSerializer.Deserialize<GeocodingResult>(jsonResponse);

            if (geocodingResult == null) return null;

            return geocodingResult.Geocode.AddressMatches;
        }
    }
}
