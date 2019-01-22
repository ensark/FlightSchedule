using System.Collections.Generic;
using System.Threading.Tasks;
using FlightSchedule.Contracts;
using FlightSchedule.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FlightSchedule.Api.Controllers
{
    [Route("flights")]
    public class FlightController : Controller
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet]
        //[SwaggerOperation("Search")]
        public ActionResult<IEnumerable<Flight>> Search([FromQuery] FlightSearchQuery query)
        {
            var queryResults = _flightService.Search(query);

            return Ok(queryResults);
        }
    }
}