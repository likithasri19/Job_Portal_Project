using JobRepository.Model;
using JobRepository.Repository;
using JobService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepo _departmentRepo;

        public DepartmentService(IDepartmentRepo departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }

        public void AddDepartment(Department department)
        {
            _departmentRepo.AddDepartment(department);
        }

        public List<Department> GetAllDepartments()
        {
            return _departmentRepo.GetAllDepartments();
        }

        public Department GetDepartmentById(int id)
        {
            return _departmentRepo.GetDepartmentById(id);
        }

        public void UpdateDepartment(Department department)
        {
            _departmentRepo.UpdateDepartment(department);
        }

        public void DeleteDepartment(int id)
        {
            _departmentRepo.DeleteDepartment(id);
        }
    }


}
