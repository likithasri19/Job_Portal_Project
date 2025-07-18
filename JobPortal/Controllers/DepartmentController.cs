using JobRepository.Model;
using JobService.Service;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    [ApiController]
    [Route("api/departments")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            return Ok(_departmentService.GetAllDepartments());
        }

        [HttpGet("id/{departmentId}")]
        public IActionResult GetDepartmentById(int departmentId)
        {
            var department = _departmentService.GetDepartmentById(departmentId);
            if (department == null)
                return NotFound($"Department with ID {departmentId} not found.");
            return Ok(department);
        }

        [HttpPost("new")]
        public IActionResult AddDepartment([FromBody] Department department)
        {
            _departmentService.AddDepartment(department);
            return Ok("Department added successfully.");
        }

        [HttpPut("update/{departmentId}")]
        public IActionResult UpdateDepartment(int departmentId, [FromBody] Department department)
        {
            var existingDepartment = _departmentService.GetDepartmentById(departmentId);
            if (existingDepartment == null)
                return NotFound($"Department with ID {departmentId} not found.");
            department.DepartmentID = departmentId;
            _departmentService.UpdateDepartment(department);
            return Ok("Department updated successfully.");
        }

        [HttpDelete("delete/{departmentId}")]
        public IActionResult DeleteDepartment(int departmentId)
        {
            var existingDepartment = _departmentService.GetDepartmentById(departmentId);
            if (existingDepartment == null)
                return NotFound($"Department with ID {departmentId} not found.");
            _departmentService.DeleteDepartment(departmentId);
            return Ok("Department deleted successfully.");
        }
    }
}
