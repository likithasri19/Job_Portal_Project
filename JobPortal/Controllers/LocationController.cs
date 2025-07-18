using JobRepository.Model;
using JobService.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JobPortal.Controllers
{
    [ApiController]
    [Route("api/locations")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        /// <summary>
        /// Get all locations.
        /// </summary>
        [HttpGet]
        public ActionResult<List<Location>> GetAllLocations()
        {
            return Ok(_locationService.GetAllLocations());
        }

        /// <summary>
        /// Get location by ID.
        /// Example: GET /api/locations/by-id/5
        /// </summary>
        [HttpGet("locationid/{locationId}")]
        public ActionResult<Location> GetLocationById(int locationId)
        {
            var location = _locationService.GetLocationById(locationId);
            if (location == null)
                return NotFound($"Location with ID {locationId} not found.");
            return Ok(location);
        }

        /// <summary>
        /// Create a new location.
        /// POST body example:
        /// {
        ///     "locationName": "Bangalore"
        /// }
        /// </summary>
        [HttpPost("addlocation")]
        public IActionResult AddLocation([FromBody] Location location)
        {
            _locationService.AddLocation(location);
            return Ok("Location added successfully.");
        }

        /// <summary>
        /// Update existing location by ID.
        /// Example: PUT /api/locations/update/5
        /// PUT body example:
        /// {
        ///     "locationName": "Updated City"
        /// }
        /// </summary>
        [HttpPut("update/{locationId}")]
        public IActionResult UpdateLocation(int locationId, [FromBody] Location location)
        {
            var existingLocation = _locationService.GetLocationById(locationId);
            if (existingLocation == null)
                return NotFound($"Location with ID {locationId} not found.");

            location.LocationID = locationId;
            _locationService.UpdateLocation(location);
            return Ok("Location updated successfully.");
        }

        /// <summary>
        /// Delete a location by ID.
        /// Example: DELETE /api/locations/delete/5
        /// </summary>
        [HttpDelete("delete/{locationId}")]
        public IActionResult DeleteLocation(int locationId)
        {
            var existingLocation = _locationService.GetLocationById(locationId);
            if (existingLocation == null)
                return NotFound($"Location with ID {locationId} not found.");

            _locationService.DeleteLocation(locationId);
            return Ok("Location deleted successfully.");
        }
    }
}

