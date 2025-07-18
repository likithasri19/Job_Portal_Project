using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using JobRepository.Model;
using JobService.Service;

namespace JobPortal.Controllers { 
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost("submit")]
        public IActionResult SubmitApplication(int userId, int jobId, string coverLetter)
        {
            try
            {
                _applicationService.SubmitApplication(userId, jobId, coverLetter);
                return Ok("Application submitted successfully.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("all")]
        public ActionResult<List<Application>> GetAllApplications()
        {
            return Ok(_applicationService.GetAllApplications());
        }

        [HttpGet("{id}")]
        public ActionResult<Application> GetApplicationById(int id)
        {
            var app = _applicationService.GetApplicationById(id);
            if (app == null)
                return NotFound($"Application with ID {id} not found.");

            return Ok(app);
        }

        [HttpGet("user/{userId}")]
        public ActionResult<List<Application>> GetUserApplications(int userId)
        {
            return Ok(_applicationService.GetUserApplications(userId));
        }

        [HttpGet("job/{jobId}")]
        public ActionResult<List<Application>> GetJobApplications(int jobId)
        {
            return Ok(_applicationService.GetJobApplications(jobId));
        }

        [HttpPut("{id}/status")]
        public IActionResult UpdateApplicationStatus(int id, [FromQuery] bool status)
        {
            var app = _applicationService.GetApplicationById(id);
            if (app == null)
                return NotFound($"Application with ID {id} not found.");

            _applicationService.UpdateApplicationStatus(id, status);
            return Ok("Application status updated successfully.");
        }

        [HttpGet("has-applied")]
        public IActionResult HasUserApplied(int userId, int jobId)
        {
            bool hasApplied = _applicationService.HasUserApplied(userId, jobId);
            return Ok(hasApplied);
        }
    }
}

