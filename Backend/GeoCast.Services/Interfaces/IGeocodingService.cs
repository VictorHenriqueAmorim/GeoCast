using GeoCast.Services.Models.Geocoding;

namespace GeoCast.Services.Interfaces
{
    public interface IGeocodingService
    {
        Task<List<AddressMatch>?> GeocodeAddressAsync(string address);
    }
}
