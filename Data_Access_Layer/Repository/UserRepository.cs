using Data_Access_Layer.DTO;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Data_Access_Layer.Models.DTO;
using log4net.Core;
using log4net.Repository.Hierarchy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{
    public class UserRepository : IUserRepository
    {
        private string secretKey;
        private readonly AppDbContext _context;
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(AppDbContext context, IConfiguration configuration, ILogger<UserRepository> logger)
        {
            secretKey = configuration.GetValue<string>("AppSettings:Key");
            _context = context;
            _logger = logger;
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                _logger.LogInformation("Initiated C");
                return await _context.Users.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it 
                _logger.LogError("Error Occured In GetUserById");
                throw;
            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            try
            {

                return await _context.Users.FirstOrDefaultAsync(u => u.EmailId == email);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it 
                throw;
            }
        }

        public async Task<User> CreateUser(User user)
        {
            try
            {
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.EmailId == user.EmailId);

                if (existingUser != null)
                {
                    // Email ID already exists in the database
                    _logger.LogInformation("EmailId Already Exist");
                    throw new Exception("Email ID already exists");
                }

                _context.Users.Add(user);
                _logger.LogInformation("User Created sucessfully");
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it 
                _logger.LogError("Error occured while creating the user");
                throw;
            }
        }


        public async Task<User> UpdateUser(User user, int id)
        {
            try
            {
                User DbUser = await _context.Users.FindAsync(id);
                DbUser.FirstName = user.FirstName;
                DbUser.LastName = user.LastName;
                DbUser.Password = user.Password;
                DbUser.EmailId = user.EmailId;
                DbUser.ContactNo = user.ContactNo;

                _logger.LogError("User Updated Sucessfully");
                _context.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it 
                _logger.LogError("Error occured while creating the user");
                throw;
            }
        }

        public async Task<LoginResponseDTO> Login(string emailId, string password)
        {
            try
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.EmailId == emailId && u.Password == password);

                if (user == null)
                {
                    // Email ID not in the database
                    _logger.LogInformation("User not Exist");
                    throw new Exception("User not exists");
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(secretKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                    {
                        new Claim("EmailId", user.EmailId.ToString()),
                        new Claim("id",user.UserId.ToString()),
                        new Claim("Password",user.Password)
                    }),
                    Expires = DateTime.UtcNow.AddDays(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                LoginResponseDTO loginResponse = new LoginResponseDTO
                {
                    EmailId = user.EmailId,
                    UserId = user.UserId,
                    Token = tokenHandler.WriteToken(token)
                };
                _logger.LogInformation("User Login successful");
                return loginResponse;
            }   
            catch (Exception ex)
            {
                // Log the exception or handle it 
                _logger.LogError("User Login failed");
                throw;
            }
        }
    }
}
