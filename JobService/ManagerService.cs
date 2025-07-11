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
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepo _managerRepo;

        public ManagerService(IManagerRepo managerRepo)
        {
            _managerRepo = managerRepo;
        }

        public void AddManager(Manager manager)
        {
            _managerRepo.AddManager(manager);
        }

        public List<Manager> GetAllManagers()
        {
            return _managerRepo.GetAllManagers();
        }

        public Manager GetManagerById(int id)
        {
            return _managerRepo.GetManagerById(id);
        }

        public void UpdateManager(Manager manager)
        {
            _managerRepo.UpdateManager(manager);
        }

        public void DeleteManager(int id)
        {
            _managerRepo.DeleteManager(id);
        }
    }

}
