using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheWorld.Models;
using TheWorld.ViewModels;

namespace TheWorld.Controllers
{
    [Route("api/trips")]
    [Authorize]
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
            return Ok(_repository.GetTripsByUsername(this.User.Identity.Name));
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]TripViewModel theTrip)
        {
            if (ModelState.IsValid)
            {
                Trip newTrip = CreateTripFromTheViewMode(theTrip);

                newTrip.UserName = User.Identity.Name;

                _repository.AddTrip(newTrip);

                var returnCode = await _repository.SaveChangesAsync();
                if (returnCode == 1)
                {
                    return Created($"api/trips/{theTrip.Name}", theTrip);
                }
            }
            return BadRequest(ModelState);
        }

        private Trip CreateTripFromTheViewMode(TripViewModel theTrip)
        {
            return new Trip
            {
                DateCreated = theTrip.Created,
                Name = theTrip.Name
            };
        }
    }
}
