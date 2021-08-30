using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Task1.Business.Interface;

namespace Task1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ISearchService _searchService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, ISearchService searchService)
        {
            _logger = logger;
            _searchService = searchService;
        }

        [HttpGet("api/{location}")]
        public async Task<IActionResult>Get(string location)
        {
            try
            {
                var result = await _searchService.SearchWeatherForLocationNr(location);
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }
    }
}
