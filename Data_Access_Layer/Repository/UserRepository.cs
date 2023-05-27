using Data_Access_Layer.DTO;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Data_Access_Layer.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

        public UserRepository(AppDbContext context , IConfiguration configuration)
        {
            secretKey = configuration.GetValue<string>("AppSettings:Key");
            _context = context;
        }
       
        

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.EmailId == email);
        }

        public async Task<User> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(User user,int id)
        {

            User DbUser = await _context.Users.FindAsync(id);
            DbUser.FirstName = user.FirstName;
            DbUser.LastName = user.LastName;
            DbUser.Password = user.Password;
            DbUser.EmailId = user.EmailId;
            DbUser.ContactNo = user.ContactNo;
           // _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return user;
        }

        public async Task<LoginResponseDTO> Login(string emailId, string password)
        {

            User user = await _context.Users.FirstOrDefaultAsync(u => u.EmailId == emailId && u.Password == password);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {

                    new Claim("EmailId", user.EmailId.ToString()),
                    new Claim("id",user.UserId.ToString()),
                    new Claim("Password",user.Password)
                   //new Claim(ClaimTypes.Version, "V3.1")
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            LoginResponseDTO loginResponse = new()
            {
                EmailId = user.EmailId,
                Token = tokenHandler.WriteToken(token)
            };

            return loginResponse;
        }


    }

}

