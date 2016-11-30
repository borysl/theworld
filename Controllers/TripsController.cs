using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheWorld.Models;
using TheWorld.ViewModels;

namespace TheWorld.Controllers
{
    [Route("api/trips")]
    public class TripsController : Controller
    {
        private readonly IWorldRepository _repository;

        public TripsController(IWorldRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok(_repository.GetAllTrips());
        }

        [HttpPost("")]
        public IActionResult Post([FromBody]TripViewModel theTrip)
        {
            if (ModelState.IsValid)
            {
                return Created($"api/trips/{theTrip.Name}", theTrip);
            }
            return BadRequest(ModelState);
        }
    }
}
