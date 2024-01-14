using GeoCast.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GeoCast.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeocodingController : ControllerBase
    {
        private readonly IGeocodingService _geocodingService;

        public GeocodingController(IGeocodingService geocodingService)
        {
            _geocodingService = geocodingService;
        }

        [HttpGet("geocode")]
        public async Task<IActionResult> GetCoordinates(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                return BadRequest("Address is required.");
            }

            try
            {
                var result = await _geocodingService.GeocodeAddressAsync(address);
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
