using GeoCast.Services.Interfaces;
using GeoCast.Services.Models.Geocoding;
using Moq;

namespace GeoCast.Tests.Services
{
    public class GeocodingServiceTests
    {
        private readonly Mock<IGeocodingService> _mockGeocodingService;
        private readonly IGeocodingService _geocodingService;
        public GeocodingServiceTests()
        {
            _mockGeocodingService = new Mock<IGeocodingService>();
        }

        [Fact]
        public async Task GeocodeAddressAsync_Should_Succeed()
        {

            // Arrange
            var validAddress = "4600 Silver Hill Rd, Washington, DC 20233";
            var mockCoordinate = new Coordinate { Latitude = 38.846016, Longitude = -76.927487 };
            var expectedCoordinate = new GeocodingResult();
            expectedCoordinate.Coordinates.Add(mockCoordinate);
            _mockGeocodingService.Setup(service => service.GeocodeAddressAsync(validAddress))
                                 .ReturnsAsync(expectedCoordinate);

            // Act
            var result = await _mockGeocodingService.Object.GeocodeAddressAsync(validAddress);

            // Assert
            Assert.Equal(expectedCoordinate, result);
        }

        [Fact]
        public async Task GeocodeAddressAsync_Should_Fail()
        {
            // Arrange
            var invalidAddress = "jsnadidpf";

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _geocodingService.GeocodeAddressAsync(invalidAddress));
            Assert.Equal("Invalid Address", exception.Message);
        }

    }
}
