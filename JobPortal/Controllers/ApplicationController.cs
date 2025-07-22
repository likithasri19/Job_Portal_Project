using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JobRepository.Model;
using JobService.Service;
using System;
using System.IO;

namespace JobPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;
        private readonly IWebHostEnvironment _env;

        public ApplicationController(IApplicationService applicationService, IWebHostEnvironment env)
        {
            _applicationService = applicationService;
            _env = env;
        }

        // ✅ SUBMIT application
        [HttpPost]
        public IActionResult SubmitApplication([FromForm] Application application, IFormFile? resume)
        {
            try
            {
                // 📝 Check if user has already applied
                if (_applicationService.HasUserApplied(application.UserID, application.JobID))
                {
                    return BadRequest("You have already applied for this job.");
                }

                // 📂 Save Resume if uploaded
                if (resume != null && resume.Length > 0)
                {
                    var uploadsFolder = Path.Combine(_env.WebRootPath ?? "wwwroot", "resumes");

                    if (!Directory.Exists(uploadsFolder))
                        Directory.CreateDirectory(uploadsFolder);

                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(resume.FileName);
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        resume.CopyTo(fileStream);
                    }

                    application.ResumePath = "/resumes/" + uniqueFileName;
                }

                // 📅 Set date and initial status
                application.ApplicationDate = DateTime.UtcNow;
                application.Status = false;

                // 🖊️ Save application and send notification
                _applicationService.SubmitApplication(application);

                return Ok(new
                {
                    message = "Application submitted successfully.",
                    applicationId = application.ApplicationID
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        // ✅ GET all applications (Admin use case)
        [HttpGet("all")]
        public IActionResult GetAllApplications()
        {
            var apps = _applicationService.GetAllApplications();
            return Ok(apps);
        }

        // ✅ GET application by ID
        [HttpGet("{id}")]
        public IActionResult GetApplicationById(int id)
        {
            var app = _applicationService.GetApplicationById(id);
            if (app == null)
                return NotFound($"Application with ID {id} not found.");

            return Ok(app);
        }

        // ✅ GET applications for a specific user
        [HttpGet("user/{userId}")]
        public IActionResult GetUserApplications(int userId)
        {
            var userApps = _applicationService.GetUserApplications(userId);
            return Ok(userApps);
        }

        // ✅ GET applications for a specific job
        [HttpGet("job/{jobId}")]
        public IActionResult GetJobApplications(int jobId)
        {
            var jobApps = _applicationService.GetJobApplications(jobId);
            return Ok(jobApps);
        }

        // ✅ UPDATE application status (approved/rejected)
        [HttpPut("{id}/status")]
        public IActionResult UpdateStatus(int id, [FromQuery] bool status)
        {
            var app = _applicationService.GetApplicationById(id);
            if (app == null)
                return NotFound($"Application with ID {id} not found.");

            _applicationService.UpdateApplicationStatus(id, status);
            return Ok(new { message = "Status updated." });
        }

        // ✅ Check if user has already applied to job
        [HttpGet("has-applied")]
        public IActionResult HasUserApplied([FromQuery] int userId, [FromQuery] int jobId)
        {
            var exists = _applicationService.HasUserApplied(userId, jobId);
            return Ok(exists);
        }
    }
}
