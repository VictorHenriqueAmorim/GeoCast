using GeoCast.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GeoCast.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("weather")]
        public async Task<IActionResult> GetWeather(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                return BadRequest("Address is required.");
            }

            try
            {
                var result = await _weatherService.GetWeather(address);

                if (result == null || result.Count == 0)
                {
                    return NotFound("No result was found for the given address.");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
