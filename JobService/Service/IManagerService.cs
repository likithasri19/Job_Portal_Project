using JobRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobService.Service
{
    public interface IManagerService
    {
        void AddManager(Manager manager);
        List<Manager> GetAllManagers();
        Manager GetManagerById(int id);
        void UpdateManager(Manager manager);
        void DeleteManager(int id);
    }
}
