using JobRepository.Model;
using JobRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobRepository
{
    public class ManagerRepository : IManagerRepo
    {
        private static List<Manager> managers = new List<Manager>();

        public void AddManager(Manager manager)
        {
            managers.Add(manager);
        }

        public List<Manager> GetAllManagers() => managers;

        public Manager GetManagerById(int id)
        {
            return managers.FirstOrDefault(m => m.ManagerID == id);
        }

        public Manager GetManagerByEmail(string email)
        {
            return managers.FirstOrDefault(m => m.Email == email);
        }

        public void UpdateManager(Manager manager)
        {
            var existing = GetManagerById(manager.ManagerID);
            if (existing != null)
            {
                existing.ManagerName = manager.ManagerName;
                existing.Email = manager.Email;
            }
        }

        public void DeleteManager(int id)
        {
            var manager = GetManagerById(id);
            if (manager != null)
            {
                managers.Remove(manager);
            }
        }
    }
}
