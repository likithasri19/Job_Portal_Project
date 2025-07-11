using JobRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobService.Service
{
    public interface IDepartmentService
    {
        void AddDepartment(Department department);
        List<Department> GetAllDepartments();
        Department GetDepartmentById(int id);
        void UpdateDepartment(Department department);
        void DeleteDepartment(int id);
    }
}
