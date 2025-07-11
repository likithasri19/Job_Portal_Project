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
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public void RegisterUser(User user)
        {
            user.JoinDate = DateTime.Now;
            _userRepo.AddUser(user);
        }

        public User LoginUser(string email, string password)
        {
            return _userRepo.ValidateUser(email, password);
        }

        public List<User> GetAllUsers()
        {
            return _userRepo.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return _userRepo.GetUserById(id);
        }

        public void UpdateUser(User user)
        {
            _userRepo.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            _userRepo.DeleteUser(id);
        }

        public List<User> GetUsersByRole(string role)
        {
            return _userRepo.GetAllUsers().Where(u => u.Role == role).ToList();
        }
    }
}
