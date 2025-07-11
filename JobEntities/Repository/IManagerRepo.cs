using JobRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobRepository.Repository
{
   
        public interface IManagerRepo
        {
            void AddManager(Manager manager);
            List<Manager> GetAllManagers();
            Manager GetManagerById(int id);
            Manager GetManagerByEmail(string email);
            void UpdateManager(Manager manager);
            void DeleteManager(int id);
        }

    }

