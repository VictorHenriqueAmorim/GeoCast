using GeoCast.Services.Interfaces;
using GeoCast.Services.Models.Geocoding;
using GeoCast.Services.Models.Weather.Points;
using GeoCast.Services.Models.Weather;
using GeoCast.Services.Services;
using Moq.Protected;
using Moq;
using System.Net;
using GeoCast.Services.Models.Weather.Point;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace GeoCast.Tests.Services
{
    public class WeatherServiceTests
    {
        private readonly Mock<IGeocodingService> _mockGeocodingService;
        private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler;
        private readonly HttpClient _httpClient;
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly WeatherService _weatherService;

        public WeatherServiceTests()
        {
            _mockGeocodingService = new Mock<IGeocodingService>();
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            _httpClient = new HttpClient(_mockHttpMessageHandler.Object);
            _httpClient.BaseAddress = new Uri("http://test.com");
            _mockConfiguration = new Mock<IConfiguration>();
            _mockConfiguration.Setup(c => c["WeatherAPI"]).Returns("http://test.com");
            _weatherService = new WeatherService(_mockGeocodingService.Object, _httpClient, _mockConfiguration.Object);
        }

        [Fact]
        public async Task GetWeather_ReturnsWeatherData_Success()
        {
            // Arrange
            var addressMatches = new List<AddressMatch>
            {
                new AddressMatch { Coordinates = new Coordinates { Latitude = 0, Longitude = 0 } }
            };

            _mockGeocodingService.Setup(s => s.GeocodeAddressAsync(It.IsAny<string>()))
                .ReturnsAsync(addressMatches);

            var gridPoint = new GridPoint
            {
                Properties = new PointProperties
                {
                    Forecast = ""
                }
            };
            var weatherData = new Weather
            {
                Location = "",
                WeatherProperties = new WeatherProperties
                {
                    WeatherPeriods = new List<WeatherPeriod>()
                }
            };

            _mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonSerializer.Serialize(gridPoint))
                })
                .Verifiable();

            _mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonSerializer.Serialize(weatherData))
                })
                .Verifiable();

            // Act
            var result = await _weatherService.GetWeather("test");

            // Assert
            Assert.Single(result);
            Assert.Equal(" X:0 Y:0", result[0].Location);
            _mockHttpMessageHandler.Protected().Verify(
                "SendAsync", Times.Exactly(2), ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
        }
    }
}
