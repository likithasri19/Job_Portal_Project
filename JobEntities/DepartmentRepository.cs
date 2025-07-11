using JobRepository.Model;
using JobRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobRepository
{
    public class DepartmentRepository : IDepartmentRepo
    {
        private static List<Department> departments = new List<Department>();

        public void AddDepartment(Department department)
        {
            departments.Add(department);
        }

        public List<Department> GetAllDepartments() => departments;

        public Department GetDepartmentById(int id)
        {
            return departments.FirstOrDefault(d => d.DepartmentID == id);
        }

        public Department GetDepartmentByName(string name)
        {
            return departments.FirstOrDefault(d => d.DepartmentName == name);
        }

        public void UpdateDepartment(Department department)
        {
            var existingDept = GetDepartmentById(department.DepartmentID);
            if (existingDept != null)
            {
                existingDept.DepartmentName = department.DepartmentName;
            }
        }

        public void DeleteDepartment(int id)
        {
            var department = GetDepartmentById(id);
            if (department != null)
            {
                departments.Remove(department);
            }
        }
    }

}
