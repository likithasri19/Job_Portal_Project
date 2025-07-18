using JobRepository.Model;
using JobRepository.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace JobRepository
{
    public class DepartmentRepository : IDepartmentRepo
    {
        private readonly JobPortalContext _context;

        public DepartmentRepository(JobPortalContext context)
        {
            _context = context;
        }

        public void AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public List<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }

        public Department GetDepartmentById(int id)
        {
            return _context.Departments.FirstOrDefault(d => d.DepartmentID == id);
        }

        public Department GetDepartmentByName(string name)
        {
            return _context.Departments.FirstOrDefault(d => d.DepartmentName == name);
        }

        public void UpdateDepartment(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
        }

        public void DeleteDepartment(int id)
        {
            var department = GetDepartmentById(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
        }
    }
}
