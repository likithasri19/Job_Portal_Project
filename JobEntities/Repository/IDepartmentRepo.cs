using JobRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobRepository.Repository
{
    public interface IDepartmentRepo
    {
        void AddDepartment(Department department);
        List<Department> GetAllDepartments();
        Department GetDepartmentById(int id);
        Department GetDepartmentByName(string name);
        void UpdateDepartment(Department department);
        void DeleteDepartment(int id);
    }

}
