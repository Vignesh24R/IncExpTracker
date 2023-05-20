using Data_Access_Layer.Models.DTO;
using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Interfaces
{
    public interface IUserBLL
    {
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string emailid);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user, int id);
        Task<LoginResponseDTO> Login(string emailId, string password);
    }
}
