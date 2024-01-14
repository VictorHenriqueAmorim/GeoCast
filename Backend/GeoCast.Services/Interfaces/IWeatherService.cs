using GeoCast.Services.Models.Weather;

namespace GeoCast.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<List<Weather>> GetWeather(string address);
    }
}
