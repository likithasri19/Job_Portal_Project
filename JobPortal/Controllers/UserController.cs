using JobRepository.Model;
using JobService.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace JobPortal.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/user
        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        // GET: api/user/{id}
        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
                return NotFound(new { message = "User not found" });

            return Ok(user);
        }

        // POST: api/user
        [HttpPost]
        public IActionResult Add(UserCreateDto userDto)
        {
            try
            {
                var user = new User
                {
                    Name = userDto.Name,
                    Email = userDto.Email,
                    Password = userDto.Password,
                    DepartmentID = userDto.DepartmentID,
                    ManagerID = userDto.ManagerID,
                    Role = userDto.Role,
                    JoinDate = userDto.JoinDate
                };

                _userService.RegisterUser(user);
                return Ok(new { message = "User added successfully", userId = user.UserID });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error adding user", error = ex.Message });
            }
        }

        // PUT: api/user/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, UserCreateDto userDto)
        {
            try
            {
                var user = new User
                {
                    UserID = id,
                    Name = userDto.Name,
                    Email = userDto.Email,
                    Password = userDto.Password,
                    DepartmentID = userDto.DepartmentID,
                    ManagerID = userDto.ManagerID,
                    Role = userDto.Role,
                    JoinDate = userDto.JoinDate
                };

                _userService.UpdateUser(user);
                return Ok(new { message = "User updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error updating user", error = ex.Message });
            }
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _userService.DeleteUser(id);
                return Ok(new { message = "User deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error deleting user", error = ex.Message });
            }
        }
    }

    // DTO used for both create and update
    public class UserCreateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int DepartmentID { get; set; }
        public int? ManagerID { get; set; }
        public string Role { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
