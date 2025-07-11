using JobRepository.Model;
using JobRepository.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace JobRepository
{
    public class UserRepository : IUserRepo
    {
        private readonly JobPortalContext _context;

        public UserRepository(JobPortalContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return _context.Users
                .Include(u => u.Department)
                .Include(u => u.Manager)
                .ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users
                .Include(u => u.Department)
                .Include(u => u.Manager)
                .FirstOrDefault(u => u.UserID == id);
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users
                .Include(u => u.Department)
                .Include(u => u.Manager)
                .FirstOrDefault(u => u.Email == email);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public User ValidateUser(string email, string password)
        {
            return _context.Users
                .Include(u => u.Department)
                .Include(u => u.Manager)
                .FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public List<User> GetUsersByDepartment(int departmentId)
        {
            return _context.Users
                .Include(u => u.Department)
                .Include(u => u.Manager)
                .Where(u => u.DepartmentID == departmentId)
                .ToList();
        }

        public List<User> SearchUsers(string keyword)
        {
            if (string.IsNullOrEmpty(keyword)) return new List<User>();

            return _context.Users
                .Include(u => u.Department)
                .Include(u => u.Manager)
                .Where(u => u.Name.Contains(keyword) ||
                            u.Email.Contains(keyword) ||
                            u.Role.Contains(keyword) ||
                            u.Department.DepartmentName.Contains(keyword))
                .ToList();
        }
    }
}
