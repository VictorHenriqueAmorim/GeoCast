using GeoCast.Services.Interfaces;
using GeoCast.Services.Models.Geocoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GeoCast.Services.Services
{
    public class GeocodingService : IGeocodingService
    {
        private readonly HttpClient _httpClient;

        public GeocodingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<AddressMatch>?> GeocodeAddressAsync(string address)
        {
            string url = $"https://geocoding.geo.census.gov/geocoder/locations/onelineaddress?address={Uri.EscapeDataString(address)}&benchmark=2020&format=json";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string jsonResponse = await response.Content.ReadAsStringAsync();
            var geocodingResult = JsonSerializer.Deserialize<GeocodingResult>(jsonResponse);

            if (geocodingResult == null) return null;

            return geocodingResult.Geocode.AddressMatches;
        }
    }
}
