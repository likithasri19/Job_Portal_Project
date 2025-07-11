using JobRepository.Model;
using JobService.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        [HttpGet]
        public List<Job> GetAll() => _jobService.GetAllJobs();

        [HttpGet("{id}")]
        public Job Get(int id) => _jobService.GetJobById(id);

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
                    Status = true, // Default to active
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

    // DTO for job creation - only required fields
    public class JobCreateDto
    {
        public string Title { get; set; }
        public int DepartmentID { get; set; }
        public int LocationID { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string PostedBy { get; set; }
    }

    // DTO for job updates
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

