using Business_Logic_Layer.Interfaces;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Data_Access_Layer.Models.DTO;
using log4net.Core;
using Microsoft.Extensions.Logging;
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

        private readonly ILogger<UserBLL> _logger;
        public UserBLL(IUserRepository userRepo, ILogger<UserBLL> logger)
        {
            _userRepo = userRepo;
            _logger = logger;
        }

        public Task<User> GetUserById(int id)
        {
            
            try
            {
                _logger.LogInformation("Initiated GetUserById");
                var res = _userRepo.GetUserById(id);
                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured while Getting user details");
                throw new ArgumentException("An error occurred while Getting User");
            }
        }
        public Task<User> GetUserByEmail(string emailid)
        {
            
            try
            {
                _logger.LogInformation("Initiated GetUserByEmail");
                var res = _userRepo.GetUserByEmail(emailid);
                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured while Getting user Email details");
                throw new ArgumentException("An error occurred while Getting User By Email");
            }
        }

        public Task<User> CreateUser(User user)
        {
            
            try
            {
                
                var res = _userRepo.CreateUser(user);
                _logger.LogInformation("User Created successfully");
                return res;

            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured while creating user");
                throw new ArgumentException("An error occurred while Creating User");
            }
        }

        public Task<User> UpdateUser(User user, int id) 
        {
            
            try
            {
                _logger.LogInformation("User Updated successfully");
                var res = _userRepo.UpdateUser(user, id);
                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured while Updating user");
                throw new ArgumentException("An error occurred while Updating User");
            }
        }

        public  Task<LoginResponseDTO> Login(string emailId, string password)
        {
            
            try
            {

                var res = _userRepo.Login(emailId, password);
                _logger.LogInformation("Login Successful");
                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError("Login Failed");
                throw new ArgumentException("An error occurred while User Login.");
            }
        }
    }
}
