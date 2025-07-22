using JobRepository.Model;
using JobService.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JobPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManagersController : ControllerBase
    {
        private readonly IManagerService _managerService;

        public ManagersController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        // GET: api/managers
        [HttpGet]
        public ActionResult<IEnumerable<Manager>> GetAllManagers()
        {
            var managers = _managerService.GetAllManagers();
            return Ok(managers);
        }

        // GET: api/managers/{id}
        [HttpGet("{id}")]
        public ActionResult<Manager> GetManagerById(int id)
        {
            var manager = _managerService.GetManagerById(id);
            if (manager == null)
            {
                return NotFound();
            }
            return Ok(manager);
        }

        // POST: api/managers
        [HttpPost]
        public ActionResult<Manager> AddManager([FromBody] Manager manager)
        {
            if (manager == null)
                return BadRequest();

            _managerService.AddManager(manager);
            return CreatedAtAction(nameof(GetManagerById), new { id = manager.ManagerID }, manager);
        }

        // PUT: api/managers
        [HttpPut]
        public IActionResult UpdateManager([FromBody] Manager manager)
        {
            if (manager == null)
                return BadRequest();

            var existing = _managerService.GetManagerById(manager.ManagerID);
            if (existing == null)
                return NotFound();

            _managerService.UpdateManager(manager);
            return NoContent();
        }

        // DELETE: api/managers/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteManager(int id)
        {
            var existing = _managerService.GetManagerById(id);
            if (existing == null)
                return NotFound();

            _managerService.DeleteManager(id);
            return NoContent();
        }
    }
}
