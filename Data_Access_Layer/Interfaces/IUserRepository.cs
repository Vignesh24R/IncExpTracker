using Data_Access_Layer.DTO;
using Data_Access_Layer.Models;
using Data_Access_Layer.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Interfaces
{
    public interface IUserRepository
    {

        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string emailid);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user, int id);
        Task<LoginResponseDTO> Login(string emailId, string password);
    }
}
