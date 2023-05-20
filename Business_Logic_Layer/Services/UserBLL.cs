using Business_Logic_Layer.Interfaces;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Data_Access_Layer.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class UserBLL : IUserBLL
    {
        private readonly IUserRepository _userRepo;

        public UserBLL(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public Task<User> GetUserById(int id)
        {
            var res = _userRepo.GetUserById(id);
            return res;
        }
        public Task<User> GetUserByEmail(string emailid)
        {
            var res = _userRepo.GetUserByEmail(emailid);
            return res;
        }

        public Task<User> CreateUser(User user)
        {
            var res = _userRepo.CreateUser(user);
            return res;
        }

        public Task<User> UpdateUser(User user, int id) 
        {
            var res = _userRepo.UpdateUser(user,id);
            return res;
        }

        public  Task<LoginResponseDTO> Login(string emailId, string password)
        {
            var res = _userRepo.Login(emailId,password);
            return res;
        }
    }
}
