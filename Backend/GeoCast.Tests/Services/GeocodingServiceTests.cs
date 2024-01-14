using GeoCast.Services.Interfaces;
using GeoCast.Services.Models.Geocoding;
using Moq;

namespace GeoCast.Tests.Services
{
    public class GeocodingServiceTests
    {
        private readonly Mock<IGeocodingService> _mockGeocodingService;

        public GeocodingServiceTests()
        {
            _mockGeocodingService = new Mock<IGeocodingService>();
        }

        [Fact]
        public async Task GeocodeAddressAsync_Should_Succeed()
        {

            // Arrange
            var validAddress = "4600 Silver Hill Rd, Washington, DC 20233";
            var mockCoordinate = new Coordinates { Latitude = 38.846016, Longitude = -76.927487 };
            var addressMatches = new List<AddressMatch> { new AddressMatch() { Coordinates = mockCoordinate, MatchedAddress = validAddress } };
            _mockGeocodingService.Setup(service => service.GeocodeAddressAsync(validAddress))
                                 .ReturnsAsync(addressMatches);

            // Act
            var result = await _mockGeocodingService.Object.GeocodeAddressAsync(validAddress);

            // Assert
            Assert.Equal(addressMatches, result);
        }
    }
}
