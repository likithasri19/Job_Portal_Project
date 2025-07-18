using JobRepository.Model;
using JobService.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace JobPortal.Controllers
{
    [ApiController]
    [Route("api/job")]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        // ✅ GET All Jobs (Flattened DTO)
        [HttpGet]
        public ActionResult<List<JobDTO>> GetAll()
        {
            var jobs = _jobService.GetAllJobs();

            var jobDTOs = jobs.Select(j => new JobDTO
            {
                JobID = j.JobID,
                Title = j.Title,
                DepartmentName = j.Department != null ? j.Department.DepartmentName : null,
                LocationName = j.Location != null ? j.Location.LocationName : null,
                Description = j.Description,
                Requirements = j.Requirements,
                Status = j.Status,
                PostedBy = j.PostedBy,
                PostedDate = j.PostedDate
            }).ToList();

            return Ok(jobDTOs);
        }

        // ✅ GET by ID (Flattened DTO)
        [HttpGet("{id}")]
        public ActionResult<JobDTO> Get(int id)
        {
            var job = _jobService.GetJobById(id);
            if (job == null)
                return NotFound(new { message = "Job not found" });

            var jobDTO = new JobDTO
            {
                JobID = job.JobID,
                Title = job.Title,
                DepartmentName = job.Department?.DepartmentName,
                LocationName = job.Location?.LocationName,
                Description = job.Description,
                Requirements = job.Requirements,
                Status = job.Status,
                PostedBy = job.PostedBy,
                PostedDate = job.PostedDate
            };

            return Ok(jobDTO);
        }

        [HttpPost]
        public IActionResult Add(JobCreateDto jobDto)
        {
            try
            {
                var job = new Job
                {
                    Title = jobDto.Title,
                    DepartmentID = jobDto.DepartmentID,
                    LocationID = jobDto.LocationID,
                    Description = jobDto.Description,
                    Requirements = jobDto.Requirements,
                    Status = true,
                    PostedBy = jobDto.PostedBy,
                    PostedDate = DateTime.Now
                };

                _jobService.CreateJob(job);
                return Ok(new { message = "Job posted successfully", jobId = job.JobID });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error posting job", error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, JobUpdateDto jobDto)
        {
            try
            {
                var job = new Job
                {
                    JobID = id,
                    Title = jobDto.Title,
                    DepartmentID = jobDto.DepartmentID,
                    LocationID = jobDto.LocationID,
                    Description = jobDto.Description,
                    Requirements = jobDto.Requirements,
                    Status = jobDto.Status,
                    PostedBy = jobDto.PostedBy,
                    PostedDate = jobDto.PostedDate
                };

                _jobService.UpdateJob(job);
                return Ok(new { message = "Job updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error updating job", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _jobService.DeleteJob(id);
                return Ok(new { message = "Job deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error deleting job", error = ex.Message });
            }
        }
    }

    // ✅ DTO for Clean Job Response
    public class JobDTO
    {
        public int JobID { get; set; }
        public string Title { get; set; }
        public string DepartmentName { get; set; }
        public string LocationName { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public bool Status { get; set; }
        public string PostedBy { get; set; }
        public DateTime PostedDate { get; set; }
    }

    // ✅ DTO for job creation
    public class JobCreateDto
    {
        public string Title { get; set; }
        public int DepartmentID { get; set; }
        public int LocationID { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string PostedBy { get; set; }
    }

    // ✅ DTO for job updates
    public class JobUpdateDto
    {
        public string Title { get; set; }
        public int DepartmentID { get; set; }
        public int LocationID { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public bool Status { get; set; }
        public string PostedBy { get; set; }
        public DateTime PostedDate { get; set; }
    }
}
