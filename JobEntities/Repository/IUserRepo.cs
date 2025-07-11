using JobRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobRepository.Repository
{
    public interface IUserRepo
    {
        void AddUser(User user);
        List<User> GetAllUsers();
        User GetUserById(int id);
        User GetUserByEmail(string email);
        void UpdateUser(User user);
        void DeleteUser(int id);
        User ValidateUser(string email, string password);
    }
}
