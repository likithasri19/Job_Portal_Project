using JobRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobService.Service
{
    public interface IUserService
    {
        void RegisterUser(User user);
        User LoginUser(string email, string password);
        List<User> GetAllUsers();
        User GetUserById(int id);
        void UpdateUser(User user);
        void DeleteUser(int id);
        List<User> GetUsersByRole(string role);
    }
}
