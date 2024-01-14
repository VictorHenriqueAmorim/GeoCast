using GeoCast.Services.Models.Geocoding;

namespace GeoCast.Services.Interfaces
{
    public interface IGeocodingService
    {
        Task<GeocodingResult> GeocodeAddressAsync(string address);
    }

}
